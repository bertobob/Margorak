using System.ComponentModel.DataAnnotations;

namespace Margorak.Api.Models
{
    public class Map
    {        
        public int MapId { get; set; }
        public string Name { get; set; } = "";
        public int SightRange { get; set; }
        public int ClickRange { get; set; }

        public ICollection<MapTile> Tiles { get; set; } = [];

    }
}
