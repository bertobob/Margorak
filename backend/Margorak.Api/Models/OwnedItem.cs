namespace Margorak.Api.Models
{
    public class OwnedItem
    {
        public int Id { get; set; }
        public int CharacterId {  get; set; }
        public Character Character { get; set; } = null!;
        public int ItemId {  get; set; }
        public Item Item { get; set; } = null!;
        public int Quantity {  get; set; }
        public int Version { get; set; }
        public ICollection<CharacterEquipment> CharacterEquipment { get; set; } = [];
    }
}
