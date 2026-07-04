namespace Margorak.Api.Models
{
    public class ItemRequirement
    {
        public int Id { get; set; }
        public int ItemId {  get; set; }
        public Item Item { get; set; } = null!;
        public int RequirementTypeId {  get; set; }
        public RequirementType RequirementType { get; set; } = null!;
        public int Value {  get; set; }

    }
}
