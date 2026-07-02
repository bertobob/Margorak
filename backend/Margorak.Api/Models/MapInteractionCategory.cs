namespace Margorak.Api.Models
{
    public class MapInteractionCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MapInteraction> Interactions { get; set; } = [];
    }
}
