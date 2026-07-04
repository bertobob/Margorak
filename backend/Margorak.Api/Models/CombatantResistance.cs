using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(CombatantId),nameof(ResistanceTypeId))]
    public class CombatantResistance
    {
        public int CombatantId {  get; set; }
        public Combatant Combatant { get; set; } = null!;
        public int ResistanceTypeId {  get; set; }  
        public ResistanceType ResistanceType { get; set; } = null!;
        public int Value { get; set; }
    }
}
