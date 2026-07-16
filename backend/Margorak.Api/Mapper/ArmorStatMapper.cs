using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class ArmorStatMapper
    {
        public static ArmorStatDto ToDto(ArmorStat armorStat)
        {
            return new ArmorStatDto
            {
                ArmorValue = armorStat.ArmorValue,
                EvasionValue = armorStat.EvasionValue,
                EquipSlot = EquipSlotMapper.ToDto(armorStat.EquipSlot)
            };
        }
    }
}
