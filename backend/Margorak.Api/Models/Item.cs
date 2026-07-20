namespace Margorak.Api.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public int Value { get; set; }
        public int Weight { get; set; }
        public int AttackRating { get; set; }
        public ICollection<ItemDamage> ItemDamages { get; set; } = [];
        public ICollection<ItemRequirement> ItemRequirements{ get; set; } = [];
        public ICollection<ItemResistance> ItemResistances{ get; set; } = [];
        public ICollection<CombatantLoot> CombatantLoots { get; set; } = [];
        public ICollection<ArmorStat> ArmorStat { get; set; } = [];
        public ICollection<ConsumableEffect> ConsumableEffect { get; set; } = [];
        public ICollection<WeaponStat> WeaponStat { get; set; } = [];
        public ICollection<OwnedItem> OwnedItems { get; set; } = [];
        public ICollection<ItemBonus> ItemBonuses { get; set; } = [];

    }
}
