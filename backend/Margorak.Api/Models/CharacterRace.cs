namespace Margorak.Api.Models
{
    public class CharacterRace
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double StrengthMod {  get; set; }
        public double DexterityMod { get; set; }
        public double VitalityMod { get; set; }
        public double IntelligenceMod { get; set; }
        public ICollection<Character> Characters { get; set; } = [];
    }
}
