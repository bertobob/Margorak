namespace Margorak.Api.Models
{
    public class ShopInteraction
    {   
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    
        public int MapInteractionId {  get; set; }
        public MapInteraction MapInteraction { get; set; } = null!;
        public string? Description { get; set; }
    }
}
