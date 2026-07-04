using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(ItemId),nameof(ResistanceTypeId))]
    public class ItemResistance
    {
        public int ItemId {  get; set; }
        public Item Item { get; set; } = null!;
        public int ResistanceTypeId {  get; set; }
        public ResistanceType ResistanceType { get; set; } = null!;
        public int Value {  get; set; }
    }
}
