namespace Margorak.Api.Dto
{
    public class MapDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MapTileDto[][] Tiles {get;set;}
        public int SightRange { get; set; }
        public int ClickRange { get; set; }
    }
}
