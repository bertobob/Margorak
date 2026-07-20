using Margorak.Api.Models;

namespace Margorak.Api.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ItemCategoryDto ItemCategory {  get; set; } = null!;
        public List<ItemDamageDto> ItemDamages { get; set; } = [];
        public List<ItemRequirementDto> ItemRequirements { get; set; } = [];
        public List<ItemResistanceDto> ItemResistances { get; set; } = [];
        public ArmorStatDto? ArmorStat { get; set; } = null;
        public WeaponStatDto? WeaponStat { get; set; } = null;
        public List<ConsumableEffectDto> ConsumableEffects { get; set; } = [];
        public List<ItemBonusDto> ItemBonuses { get; set; } = [];
        public string Description {  get; set; } = string.Empty;
        public int Value {  get; set; }
        public int Weight {  get; set; }
        public int AttackRating { get; set; }
    }
}
