using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(AttackId), nameof(DamageTypeId))]
    public class AttackDamage
    {
        public int AttackId {  get; set; }
        public Attack Attack{ get; set; } = null!;

        public int DamageTypeId {  get; set; }

        public DamageType DamageType { get; set; } = null!;
        public int MinDamage {  get; set; }
        public int MaxDamage { get; set; }
        

    }
}
