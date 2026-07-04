namespace Margorak.Api.Models
{
    public class Terrain
    {
        public int TerrainId { get; set; }  
        public string Name { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public int Accessible { get; set; }
        public string Category { get; set; } = string.Empty;
        public ICollection<MapTile> MapTiles { get; set; } = [];
    }
}
