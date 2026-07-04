using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Data
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<ArmorStat> ArmorStats => Set<ArmorStat>();
        public DbSet<Attack> Attacks => Set<Attack>();
        public DbSet<AttackDamage> AttackDamages => Set<AttackDamage>();
        public DbSet<BonusType> BonusTypes => Set<BonusType>();
        public DbSet<Character> Characters => Set<Character>();
        public DbSet<CharacterClass> CharacterClasses => Set<CharacterClass>();
        public DbSet<CharacterEquipment> CharacterEquipment => Set<CharacterEquipment>();
        public DbSet<CharacterRace> CharacterRaces => Set<CharacterRace>();
        public DbSet<Combatant> Combatants => Set<Combatant>();
        public DbSet<CombatantAttack> CombatantAttacks => Set<CombatantAttack>();
        public DbSet<CombatantHabitat> CombatantHabitats => Set<CombatantHabitat>();
        public DbSet<CombatantLoot> CombatantLoots => Set<CombatantLoot>();
        public DbSet<CombatantRace> CombatantRaces => Set<CombatantRace>();
        public DbSet<CombatantResistance> CombatantResistances => Set<CombatantResistance>();
        public DbSet<ConsumableEffect> ConsumableEffects => Set<ConsumableEffect>();
        public DbSet<DamageType> DamageTypes => Set<DamageType>();
        public DbSet<EffectType> EffectTypes => Set<EffectType>();
        public DbSet<EquipSlot> EquipSlots => Set<EquipSlot>();
        public DbSet<HabitatTerrainType> HabitatTerrainTypes => Set<HabitatTerrainType>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<ItemBonus> ItemBonuses => Set<ItemBonus>();
        public DbSet<ItemCategory> ItemCategories => Set<ItemCategory>();
        public DbSet<ItemDamage> ItemDamages => Set<ItemDamage>();
        public DbSet<ItemRequirement> ItemRequirements => Set<ItemRequirement>();
        public DbSet<ItemResistance> ItemResistances => Set<ItemResistance>();
        public DbSet<Level> Levels => Set<Level>();
        public DbSet<Map> Maps => Set<Map>();
        public DbSet<MapInteraction> MapInteractions => Set<MapInteraction>();
        public DbSet<MapInteractionCategory> MapInteractionCategories => Set<MapInteractionCategory>();
        public DbSet<MapTile> MapTiles => Set<MapTile>();
        public DbSet<OwnedItem> OwnedItems => Set<OwnedItem>();
        public DbSet<RequirementType> RequirementTypes => Set<RequirementType>();
        public DbSet<ResistanceType> ResistanceTypes => Set<ResistanceType>();
        public DbSet<ShopInteraction> ShopInteractions => Set<ShopInteraction>();
        public DbSet<TeleporterInteraction> TeleporterInteractions => Set<TeleporterInteraction>();
        public DbSet<Terrain> Terrains => Set<Terrain>();
        public DbSet<WeaponStat> WeaponStats => Set<WeaponStat>();
    }
}
