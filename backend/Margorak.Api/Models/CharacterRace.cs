namespace Margorak.Api.Models
{
    public class CharacterRace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double StrengthMod {  get; set; }
        public double DexteryMod { get; set; }
        public double VitalityMod { get; set; }
        public double IntelligenceMod { get; set; }
    }
}
