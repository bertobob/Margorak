namespace Margorak.Api.Models
{
    public class Effectype
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ConsumableEffect> ConsumableEffect { get; set; } = [];
    }
}
