namespace Margorak.Api.Dto
{
    public abstract class MapInteractionDto
    {
        public int Id { get; set; }
        public string Type { get;set; }
    }

    public class ShopInteractionDto :MapInteractionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class TeleporterInteractionDto : MapInteractionDto
    {
        public string Description { set; get; }
        public int DestinationMapId {  get; set; }
        public int DestinationLocX { get; set; }
        public int DestinationLocY { get; set; }

    }
}
