namespace Margorak.Api.Dto
{
    public class InventoryItemDto
    {
        public ItemDto Item { get; set; } = null!;
        public int Quantity {  get; set; }
    }
}
