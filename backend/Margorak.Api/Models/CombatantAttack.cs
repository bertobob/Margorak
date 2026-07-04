using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(CombatantId),nameof(AttackId))]
    public class CombatantAttack
    {
        public int CombatantId {  get; set; }
        public Combatant Combatant { get; set; } = null!;
        public int AttackId {  get; set; }
        public Attack Attack { get; set; }= null!;
        public double AttackCount {  get; set; }

    }
}
