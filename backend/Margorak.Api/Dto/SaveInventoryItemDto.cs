namespace Margorak.Api.Dto
{
    public class SaveInventoryItemDto
    {
        public int ItemId { get; set; }
        public int? OwnedItemId {  get; set; }
        public int Quantity {  get; set; }
    }
}
