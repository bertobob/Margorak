namespace Margorak.Api.Models
{
    public class RequirementType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ItemRequirement> ItemRequirements { get; set; } = [];
    }
}
