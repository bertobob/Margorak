namespace Margorak.Api.Models
{
    public class Terrain
    {
        public int TerrainId { get; set; }  
        public string Name { get; set; }
        public string ImageName { get; set; }
        public int Accessible { get; set; }
        public string Category { get; set; }
    }
}
