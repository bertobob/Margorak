namespace Margorak.Api.Dto
{
    public class InventoryItemDto
    {
        public int ItemId {  get; set; }
        public string Name { get; set; } = string.Empty;
        public ItemCategoryDto Category { get; set; } = null!;
        public int Quantity {  get; set; }
    }
}
