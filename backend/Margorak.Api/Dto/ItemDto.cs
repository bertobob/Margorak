using Margorak.Api.Models;

namespace Margorak.Api.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ItemCategoryDto ItemCategory {  get; set; } = null!;
        public string Description {  get; set; } = string.Empty;
        public int Value {  get; set; }
        public int Weight {  get; set; }
    }
}
