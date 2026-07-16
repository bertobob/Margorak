using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class WeaponStatMapper
    {
        public static WeaponStatDto ToDto(WeaponStat weaponStat)
        {
            return new WeaponStatDto
            {
                AttackSpeed = weaponStat.AttackSpeed,
                AttackRange = weaponStat.AttackRange
            };
        }
    }
}
