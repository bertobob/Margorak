namespace Margorak.Api.Models
{
    public class EquipSlot
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ArmorStat> ArmorStat { get; set; } = [];
        public ICollection<CharacterEquipment> CharacterEquipment { get; set; } = [];

    }
}
