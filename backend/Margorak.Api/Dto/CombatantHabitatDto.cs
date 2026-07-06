using Margorak.Api.Models;

namespace Margorak.Api.Dto
{
    public class CombatantHabitatDto
    {
        public int CombatantHabitatId { get; set; }
        public int TerrainTypeId { get; set; } 
        public int LocX1 {  get; set; }
        public int LocY1 { get; set; }
        public int LocX2 {  get; set; }
        public int LocY2 { get; set; }
        public int Probability {  get; set; }
        public int AmbushProbability {  get; set; }

    }
}
