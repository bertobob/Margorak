namespace Margorak.Api.Models
{
    public class EquipSlot
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public ICollection<ArmorStat> ArmorStat { get; set; } = [];
    }
}
