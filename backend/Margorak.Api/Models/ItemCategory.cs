namespace Margorak.Api.Models
{
    public class ItemCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? EquipSlotId { get; set; }
        public EquipSlot? EquipSlot { get; set; }
        public ICollection<Item> Items { get; set; } = [];
    }
}
