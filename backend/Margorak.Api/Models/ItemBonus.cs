namespace Margorak.Api.Models
{
    public class ItemBonus
    {
        public int Id { get; set; }
        public int ItemId {  get; set; }
        public Item Item { get; set; }
        public int BonusTypeId {  get; set; }
        public BonusType BonusType { get; set; }
        public int Value {  get; set; }

    }
}
