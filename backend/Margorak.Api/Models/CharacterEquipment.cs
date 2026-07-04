using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(CharacterId),nameof(EquipSlotId))]
    public class CharacterEquipment
    {
        public int CharacterId {  get; set; }
        public Character  Character { get; set; } = null!;
        public int EquipSlotId { get; set; }
        public EquipSlot EquipSlot { get; set; } = null!;
        public int OwnedItemId {  get; set; }
        public OwnedItem OwnedItem { get; set; } = null!;
        public int Version { get; set; }

    }
}
