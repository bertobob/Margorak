using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(ShopInteractionId), nameof(ItemId))]
    public class ShopItem
    {
        public int ShopInteractionId { get; set; }
        public ShopInteraction ShopInteraction { get; set; } = null!;
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
    }
}
