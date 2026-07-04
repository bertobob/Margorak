using System.ComponentModel.DataAnnotations;

namespace Margorak.Api.Models
{
    public class WeaponStat
    {
        [Key]
        public int ItemId {  get; set; }
        public Item Item { get; set; } = null!;
        public int AttackSpeed {  get; set; }   
        public int AttackRange {  get; set; }

    }
}
