namespace Margorak.Api.Dto
{
    public class CreateCharacterDto
    {
        public string Name { get; set; } = string.Empty;
        public int CharacterRaceId {  get; set; }
        public int CharacterClassId { get; set; }
    }
}
