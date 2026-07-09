using System.Text.Json.Serialization;

namespace Margorak.Api.Dto
{

    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ShopInteractionDto), "shop")]
    [JsonDerivedType(typeof(TeleporterInteractionDto), "teleporter")]
    public abstract class MapInteractionDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    public class ShopInteractionDto :MapInteractionDto
    {
        public string ShopName { get; set; } = string.Empty;
    }

    public class TeleporterInteractionDto : MapInteractionDto
    {
        public int DestinationMapId {  get; set; }
        public int DestinationLocX { get; set; }
        public int DestinationLocY { get; set; }

    }
}
