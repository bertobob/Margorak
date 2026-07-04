namespace Margorak.Api.Models
{
    public class CharacterClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Character> Characters { get; set; } = [];
    }
}
