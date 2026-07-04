using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(CombatantId),nameof(ItemId))]
    public class CombatantLoot
    {
        public int CombatantId { get; set; }
        public Combatant Combatant { get; set; }
        public int ItemId {  get; set; }
        public Item Item { get; set; }
        public int Probability {  get; set; }
    }
}
