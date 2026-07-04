namespace Margorak.Api.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }
        public ICollection<ItemDamage> ItemDamages { get; set; } = [];
        public ICollection<ItemRequirement> ItemRequirements{ get; set; } = [];
        public ICollection<ItemResistance> ItemResistances{ get; set; } = [];
        public ICollection<CombatantLoot> CombatantLoots { get; set; } = [];
        public ICollection<ArmorStat> ArmorStat { get; set; } = [];
        public ICollection<ConsumableEffect> ConsumableEffect { get; set; } = [];
        public ICollection<WeaponStat> WeaponStat { get; set; } = [];

    }
}
