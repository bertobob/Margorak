namespace Margorak.Api.Models
{
    public class MapInteraction
    {
        public int Id { get; set; }
        public int MapId { get;set; }
        public int LocX { get;set; }
        public int LocY { get;set; }
        public Map Map { get; set; } = null!;
        public int MapInteractionCategoryId {  get; set; }
        public MapInteractionCategory Category { get; set; } = null!;
        public ShopInteraction? ShopInteraction { get; set; }
        public TeleporterInteraction? TeleporterInteraction { get; set; }
    }

}
