using Margorak.Api.Models;

namespace Margorak.Api.Services.combat
{
    internal sealed class CombatContext
    {
        public required ActiveCombat ActiveCombat { get; init; }
        public required Character Character { get; init; }
        public required Combatant Combatant { get; init; }                
        public required ActiveCombatCombatant ActiveCombatCombatant { get; init; } 
        public required int CharacterAttackSpeed { get; init; }           
        public required int CharacterAttackRating { get; init; }
        public required int CombatantAttackSpeed { get; init; }
        public required int CombatantAttackRating { get; init; }
        public required IReadOnlyDictionary<string, int> CombatantResistances { get; init; }
        public required IReadOnlyDictionary<string, (int,int)> CharacterDamages { get; init; }
        public required IReadOnlyDictionary<string, int> CharacterResistances { get; init; }
    }
}

