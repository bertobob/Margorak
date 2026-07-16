using Margorak.Api.Models;

namespace Margorak.Api.Dto
{
    public class ItemDamageDto
    {   
        public DamageTypeDto DamageType { get; set; } = null!;
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
    }
}
