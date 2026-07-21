namespace Margorak.Api.Dto
{
    public class InventoryItemDto
    {
        public ItemDto Item { get; set; } = null!;
        public int OwnedItemId { get; set; }
        public int Quantity {  get; set; }
    }
}
