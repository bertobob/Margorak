using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(ItemId), nameof(RequirementTypeId))]
    public class ItemRequirement
    {
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        public int RequirementTypeId { get; set; }
        public RequirementType RequirementType { get; set; } = null!;
        public int Value { get; set; }
    }
}
