namespace Margorak.Api.Dto
{
    public class TradeItemResponseDto
    {
        public int RemainingGold {  get; set; }
        public List<InventoryItemDto> InventoryItems { get; set; } = [];
    }
}
