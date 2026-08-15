using Margorak.Api.Models;

namespace Margorak.Api.Dto
{
    public class CombatantLootDto
    {
        public List<Item> ItemList { get; set; } = [];
        public int GoldLoot { get; set; } = 0;
    }
}
