namespace Margorak.Api.Models
{
    public class ResistanceType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ItemResistance> ItemResistances { get; set; } = [];
        public ICollection<CombatantResistance> CombatantResistances { get; set; } = [];
    }
}
