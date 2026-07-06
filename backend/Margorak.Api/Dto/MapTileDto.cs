namespace Margorak.Api.Dto
{
    public class MapTileDto
    {
        public int TerrainId { get; set; }
        public int TerrainTypeId { get; set; }
        public bool Accessible { get; set; }
        public MapInteractionDto? MapInteraction {get;set;}
    }
}
