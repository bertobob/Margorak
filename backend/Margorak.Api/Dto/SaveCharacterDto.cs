namespace Margorak.Api.Dto
{
    public class SaveCharacterDto
    {
        public LocationDto Location { get; set; } = null!;
        public EquippedItemDto[] EquippedItems { get; set; } = [];
        public InventoryItemDto[] InventoryItems { get; set; } = [];
    }
}
