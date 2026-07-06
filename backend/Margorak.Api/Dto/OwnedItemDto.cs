namespace Margorak.Api.Dto
{
    public class OwnedItemDto
    {
        public int Id { get; set; }
        public ItemDto Item { get; set; } = null!;
        public int Quantity { get; set; }
        public int Version {  get; set; }
    }
}
