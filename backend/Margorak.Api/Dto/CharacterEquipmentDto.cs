using System.Diagnostics.Contracts;

namespace Margorak.Api.Dto
{
    public class CharacterEquipmentDto
    {
        public EquipSlotDto EquipSlot { get; set; } = null!;
        public OwnedItemDto OwnedItem { get; set; } = null!;
        public int Version { get; set; }       
    }
}
