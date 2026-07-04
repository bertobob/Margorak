namespace Margorak.Api.Dto
{
    public abstract class MapInteractionDto
    {
        public int Id { get; set; }
        public string Type { get;set; } = string.Empty;
    }

    public class ShopInteractionDto :MapInteractionDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class TeleporterInteractionDto : MapInteractionDto
    {
        public string Description { set; get; } = string.Empty;
        public int DestinationMapId {  get; set; }
        public int DestinationLocX { get; set; }
        public int DestinationLocY { get; set; }

    }
}
