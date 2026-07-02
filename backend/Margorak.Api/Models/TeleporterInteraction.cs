namespace Margorak.Api.Models
{
    public class TeleporterInteraction
    {
        public int Id { get; set; }
        
        public int MapInteractionId { get; set; }
        public MapInteraction MapInteraction { get; set; } = null;
        public string? Description { get; set; } 
        public int DestinationMapId { get; set; }
        public Map DestinationMap { get; set; } = null!;
        public int DestinationLocX {  get; set; }   
        public int DestinationLocY { get; set; }
    }
}
