using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class EquipSlotMapper
    {
        public static EquipSlotDto ToDto(EquipSlot equipSlot)
        {
            return new EquipSlotDto
            {
                Id = equipSlot.Id,
                Name = equipSlot.Name,
            };
        }
    }
}
