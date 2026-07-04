namespace Margorak.Api.Models
{
    public class EffectType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ConsumableEffect> ConsumableEffect { get; set; } = [];
    }
}
