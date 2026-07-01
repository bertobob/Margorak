using System.ComponentModel.DataAnnotations;

namespace Margorak.Api.Models
{
    public class MapTile
    {
        [Key]
        public int MapTileId { get; set; }
        public int MapId { get; set; }
        public Map Map { get; set; } = null!;
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public int TerrainId {  get; set; }
        public Terrain Terrain { get; set; } = null!;
        


    }
}
