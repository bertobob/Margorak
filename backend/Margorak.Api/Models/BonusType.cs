namespace Margorak.Api.Models
{
    public class BonusType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ItemBonus> ItemBonuses { get; set; } = [];
    }
}
