namespace Margorak.Api.Models
{
    public class ResistanceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ItemResistance> ItemResistances { get; set; } = null!;
    }
}
