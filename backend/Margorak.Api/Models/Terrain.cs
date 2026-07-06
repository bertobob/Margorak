namespace Margorak.Api.Models
{
    public class Terrain
    {
        public int TerrainId { get; set; }  
        public int TerrainTypeId { get; set; }
        public TerrainType TerrainType { get; set; } = null!;

        public string Name { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public int Accessible { get; set; }
        
        public ICollection<MapTile> MapTiles { get; set; } = [];
    }
}
