using Margorak.Api.Dto;
using Margorak.Api.Enums;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Margorak.Api.Services.combat;
using System.Text;

namespace Margorak.Api.Services
{
    public class CombatService
    {
        private readonly ICombatantRepository _combatantRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly ICombatRepository _combatRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CombatService(
            ICombatantRepository combatantRepository,
            ICharacterRepository characterRepository,
            ICombatRepository combatRepository,
            IUnitOfWork unitOfWork)
        {
            _combatantRepository = combatantRepository;
            _characterRepository = characterRepository;
            _combatRepository = combatRepository;
            _unitOfWork = unitOfWork;
        }

        const int MinimumHitChance = 5;
        const int MaximumHitChance = 95;
        /*
         * The character always attacks first
         * after that, the combatant attack as long its timeline is behind
         * the characters timeline
         * As of now, only 1 Combatant is possible
         */
        public async Task<ActiveCombatDto> Attack(int characterId)
        {
            var combatContext = await GetCombatContextAsync(characterId);
            var combatState = CreateCombatState(combatContext.ActiveCombat, combatContext.ActiveCombatCombatant, combatContext.Character);

            await ProcessCharacterTurnAsync(combatContext, combatState);

            if (combatState.CombatantDead)
            {
                return await ProcessCombatantDefeated(combatState.Log, combatContext.Combatant, combatContext.Character);
            }

            combatState.CharacterTimeLine += combatContext.CharacterAttackSpeed;
            await _combatRepository.UpdateCharacterTimelineAsync(combatContext.ActiveCombatCombatant, combatContext.CharacterAttackSpeed);
            
            await ProcessCombatantTurnAsync(combatContext, combatState);

            if (!combatState.CharacterDead)
            {
                var oldCombatantTimeline = combatContext.ActiveCombatCombatant.CombatantTimeline;
                if (oldCombatantTimeline != combatState.CombatantTimeLine)
                {
                    await _combatRepository.UpdateCombatantTimelineAsync(combatContext.ActiveCombatCombatant, combatState.CombatantTimeLine - oldCombatantTimeline);
                }
            }

            await _unitOfWork.SaveChangesAsync();

            if (combatState.CharacterDead)
            {
                return new ActiveCombatDto
                {
                    CombatantName = combatContext.Combatant.Name,
                    CombatantImageKey = combatContext.Combatant.ImageKey,
                    CurrentCharacterHp = 0,
                    CurrentCombatantHp = combatState.CombatantCurrentHp,
                    CombatantMaxHp = combatContext.Combatant.BaseHp,
                    CombatLogs = combatState.Log.ToString(),
                    BattleOver = true
                };
            }

            return new ActiveCombatDto
            {
                CombatantName = combatContext.Combatant.Name,
                CombatantImageKey = combatContext.Combatant.ImageKey,
                CurrentCharacterHp = combatState.CharacterCurrentHp,
                CurrentCombatantHp = combatState.CombatantCurrentHp,
                CombatantMaxHp = combatContext.Combatant.BaseHp,
                CombatLogs = combatState.Log.ToString()
            };
        }

        private async Task ProcessCharacterTurnAsync(CombatContext combatContext, CombatState combatState)
        {            
            if (IsHit(combatContext.CharacterAttackRating, combatContext.CombatantResistances["evasion"]))
            {
                var hpLoss = CalculateHpLoss(combatContext.CharacterDamages, combatContext.CombatantResistances);

                combatState.CombatantCurrentHp -= hpLoss;
                combatState.Log.AppendLine($"You hit {combatContext.Combatant.Name} for {hpLoss} damage.");

                if (combatState.CombatantDead)
                {
                    return;
                }

                await _combatRepository.UpdateActiveCombatCombatantHpAsync(combatContext.ActiveCombatCombatant, -hpLoss);
            }
            else
            {
                combatState.Log.AppendLine($"You miss {combatContext.Combatant.Name}.");
            }
        }
        private async Task ProcessCombatantTurnAsync(CombatContext combatContext, CombatState combatState)
        {
            while (combatState.CombatantTimeLine <= combatState.CharacterTimeLine)
            {
                if (IsHit(combatContext.CombatantAttackRating, combatContext.CharacterResistances["evasion"]))
                {
                    var combatantDamages = GetCombatantAttackDamages(combatContext.Combatant);
                    var hpLoss = CalculateHpLoss(combatantDamages, combatContext.CharacterResistances);
                    await _characterRepository.UpdateCharacterHpAsync(combatContext.Character.Id, -hpLoss);
                    combatState.CharacterCurrentHp -= hpLoss;
                    combatState.Log.AppendLine($"{combatContext.Combatant.Name} {combatContext.Combatant.CombatantAttacks.First().Attack.Description} and hits you for {hpLoss} damage.");
                    if (combatState.CharacterDead)
                    {
                        combatState.Log.AppendLine($"You have been defeated by {combatContext.Combatant.Name}.");
                        _characterRepository.StopCombat(combatContext.Character.Id);                        
                        return;
                    }
                }
                else
                {
                    combatState.Log.AppendLine($"{combatContext.Combatant.Name} misses you.");
                }

                combatState.CombatantTimeLine += combatContext.CombatantAttackSpeed;
            }
        }
        private async Task<CombatContext> GetCombatContextAsync(int characterId)
        {            
            var activeCombat = await _combatRepository.GetActiveCombatAsync(characterId);

            if (activeCombat == null)
            {
                throw new InvalidOperationException(
                    $"Activecombat for {characterId} does not exist");
            }

            var activeCombatCombatant = activeCombat.ActiveCombatCombatants.FirstOrDefault()
                ?? throw new InvalidOperationException(
                    $"ActiveCombat {activeCombat.Id} has no combatant.");

            var character = await _characterRepository.GetCompleteCharacterAsync(characterId);
            var combatant = await _combatantRepository.GetCombatantForBattleAsync(activeCombatCombatant.CombatantId);
            if (character == null || combatant == null)
            {
                throw new InvalidOperationException(
                    $"Participants of ActiveCombat {activeCombat.Id} not valid.");
            }

            var characterAttackSpeed = GetCharacterAttackSpeed(character);
            var characterAttackRating = GetCharacterAttackRating(character);
            var combatantResistances = GetCombatantResistances(combatant);
            var characterDamages = GetCharacterAttackDamages(character);

            var combatantAttack = combatant.CombatantAttacks.FirstOrDefault()
                ?? throw new InvalidOperationException(
                    $"Combatant {combatant.Id} has no valid attacks.");

            var combatantAttackRating = combatantAttack.Attack.AttackRating;
            var combatantAttackSpeed = combatantAttack.Attack.AttackSpeed;
            var characterResistances = GetCharacterResistances(character);
            return new CombatContext
            {
                ActiveCombat = activeCombat,
                Character = character,
                Combatant = combatant,
                ActiveCombatCombatant = activeCombatCombatant,
                CharacterAttackSpeed = characterAttackSpeed,
                CharacterAttackRating = characterAttackRating,
                CombatantAttackSpeed = combatantAttackSpeed,
                CombatantAttackRating = combatantAttackRating,
                CombatantResistances = combatantResistances,
                CharacterDamages = characterDamages,
                CharacterResistances = characterResistances
            };
            
            
        }

        private CombatState CreateCombatState(            
            ActiveCombat activeCombat,
            ActiveCombatCombatant activeCombatCombatant,
            Character character)
        {
            var log = new StringBuilder();
            
            return new CombatState
            {
                CharacterCurrentHp = character.CurrentHp,
                CharacterTimeLine = activeCombat.CharacterTimeline,
                CombatantCurrentHp = activeCombatCombatant.CurrentHp,
                CombatantTimeLine = activeCombatCombatant.CombatantTimeline,
                Log = log
            };
        }
        private  async Task <ActiveCombatDto> ProcessCombatantDefeated( StringBuilder log,Combatant combatant, Character character)
        {
            log.AppendLine($"You have defeated {combatant.Name}.");
            var loot = await GetLootByCombatantAsync(combatant, character.Id);
            log.AppendLine(BuildLogEntryFromLoot(loot));
            var experience = await _characterRepository.AddExpByCharacterAndCombatantIdAsync(character.Id, combatant.Id);
            log.AppendLine($"You gained {experience} experience.");
            var levelupResult = await CheckAndDoLevelup(character, experience);
            if (!string.IsNullOrEmpty(levelupResult))
            {
                log.AppendLine(levelupResult);
            }
            _characterRepository.StopCombat(character.Id);

            await _unitOfWork.SaveChangesAsync();

            return new ActiveCombatDto
            {
                CombatantName = combatant.Name,
                CombatantImageKey = combatant.ImageKey,
                CurrentCharacterHp = character.CurrentHp,
                CurrentCombatantHp = 0,
                CombatantMaxHp = combatant.BaseHp,
                CombatLogs = log.ToString(),
                BattleOver = true
            };
        }
        private async Task<string> CheckAndDoLevelup(Character character, int experience)
        {
            var level = await _characterRepository.GetLevelByExperienceAsync(character.Experience+experience);
            if(level > character.Level)
            {
                await _characterRepository.UpdateCharacterLevelAndStatPointsAsync(character.Id, level);
                return $"You are now Level {level}.";
            }

            return "";

        }
        private string BuildLogEntryFromLoot(CombatantLootDto loot)
        {
            if (loot.ItemList.Count == 0)
            {
                return $"You found {loot.GoldLoot} gold.";
            }

            var items = string.Join(
                ", ",
                loot.ItemList.Select(item => $"1 {item.Name}")
            );

            return $"You found {items} and {loot.GoldLoot} gold.";
        }
        private async Task<CombatantLootDto> GetLootByCombatantAsync(Combatant combatant,int characterId)
        {
            const int MaxProbability = 100000;
            var itemLoot = new List<Item>();
            var possibleLoots = await _combatantRepository.GetLootByCombatantIdAsync(combatant.Id);

            foreach(var possibleLoot in possibleLoots)
            {
                if(possibleLoot.Probability >= Random.Shared.Next(0,MaxProbability))
                {
                    itemLoot.Add(possibleLoot.Item);
                }
            }

            var goldLoot = Random.Shared.Next(combatant.GoldLootMin, combatant.GoldLootMax + 1);

            await _characterRepository.AddItemsToInventoryAsync(characterId,itemLoot,goldLoot);

            return new CombatantLootDto
            {
                ItemList = itemLoot,
                GoldLoot = goldLoot,
            };
        }
        private int GetCharacterAttackRating(Character character)
        {
            return character.CharacterEquipment.Sum(ce => ce.OwnedItem.Item.AttackRating) + character.Dexterity/2;
        }
        private Dictionary<string, int> GetCharacterResistances(Character character)
        {
            var resistances = CreateNewResistancesDictionary();

            foreach (var item in character.CharacterEquipment)
            {
                foreach(var resistance in item.OwnedItem.Item.ItemResistances)
                {
                    var key =  resistance.ResistanceType.Name.ToLower();

                    resistances[key] = resistances[key] + resistance.Value;
                }
            }

            return resistances;
        }

        private Dictionary<string, (int minDamage, int maxDamage)> GetCombatantAttackDamages(Combatant combatant)
        {
            var damageTypes = CreateNewDamageDictionary();

            var attackDamages =combatant.CombatantAttacks.FirstOrDefault()?.Attack.AttackDamages;
            if(attackDamages == null)
            {
                throw new InvalidOperationException(
                    $"Combatant {combatant.Id} has no Attacks)");
            }

            foreach(var attackDamage in attackDamages)
            {
                var key = attackDamage.DamageType.Name.ToLower();
                damageTypes[key] = (
                    damageTypes[key].minDamage + attackDamage.MinDamage,
                    damageTypes[key].maxDamage + attackDamage.MaxDamage);
            }

            return damageTypes;
        }
        private int GetCharacterAttackSpeed(Character character)
        {
            var attackSpeed = 0;
            const int DefaultAttackspeed = 30;
            foreach (var item in character.CharacterEquipment)
            {
                foreach (var weaponStat in item.OwnedItem.Item.WeaponStat)
                {
                    attackSpeed += weaponStat.AttackSpeed;
                }
            }

            return attackSpeed>0 ? attackSpeed : DefaultAttackspeed;
        }
        private int CalculateHpLoss(IReadOnlyDictionary<string, (int minDamage, int maxDamage)> damages, IReadOnlyDictionary<string, int> resistances)
        {
            int hpLoss = 1;
            foreach(var damage in damages)
            {
                var damageValue = Random.Shared.Next(damage.Value.minDamage,damage.Value.maxDamage+1);
                var calculatedDamage = (int)damageValue * (100 - resistances[damage.Key.ToLower()]) / 100;
                if(damage.Key == "physical")
                {
                    calculatedDamage = Math.Max(0, calculatedDamage - resistances["defense"]);
                }

                hpLoss += calculatedDamage;
            }

            return hpLoss;
        }
        private Dictionary<string,int> GetCombatantResistances(Combatant combatant)
        {
            var resistances = CreateNewResistancesDictionary();

            foreach ( var resistance in combatant.CombatantResistances)
            {
                var key= resistance.ResistanceType.Name.ToLower();

                resistances[key] += resistance.Value;
            }

            return resistances;

        }

        private Dictionary<string, (int minDamage, int maxDamage)> GetCharacterAttackDamages(Character character)
        {
            var damageTypes = CreateNewDamageDictionary();


            foreach (var item in character.CharacterEquipment)
            {
                foreach (var damageType in item.OwnedItem.Item.ItemDamages)
                {
                    var key = damageType.DamageType.Name.ToLower();
                    damageTypes[key] = (
                        damageType.MinDamage + damageTypes[key].minDamage,
                        damageType.MaxDamage + damageTypes[key].maxDamage);
                }
            }
            // apply race modifier
            damageTypes["physical"] = (
                    (int)(damageTypes["physical"].minDamage * (1 + character.CharacterRace.StrengthMod * character.Strength / 100)),
                    (int)(damageTypes["physical"].maxDamage * (1 + character.CharacterRace.StrengthMod * character.Strength / 100))
                );

            return damageTypes;
        }
        private bool IsHit(int attackRating, int evasion)
        {
            //TODO formel ausbessern
            var hitChance = Math.Clamp(
                (attackRating *100) / ( evasion+20),
                MinimumHitChance,
                MaximumHitChance);

            return hitChance >= Random.Shared.Next(101);
        }

        private static Dictionary<string,(int minDamage, int maxDamage)> CreateNewDamageDictionary()
        {
            return Enum.GetValues<DamageKind>()
                .ToDictionary(
                    type => type.ToString().ToLowerInvariant(),
                    damagerange => (0, 0));
        }

        private static Dictionary<string,int> CreateNewResistancesDictionary()
        {
            return Enum.GetValues<ResistanceKind>()
                .ToDictionary(
                    type => type.ToString().ToLowerInvariant(),
                    value => 0);
        }
    }
}
