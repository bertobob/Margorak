using System.ComponentModel.DataAnnotations;

namespace Margorak.Api.Models
{
    public class ArmorStat
    {
        [Key]
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        public int ArmorValue {  get; set; }
        public int EvasionValue { get; set; }
    }
}
