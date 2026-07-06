using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class CharacterEquipmentMapper
    {
        public static CharacterEquipmentDto ToDto(CharacterEquipment characterEquipment)
        {
            var equipSlot = EquipSlotMapper.ToDto(characterEquipment.EquipSlot);
            var ownedItem = OwnedItemMapper.ToDto(characterEquipment.OwnedItem);

            return new CharacterEquipmentDto
            {
                EquipSlot = equipSlot,
                OwnedItem = ownedItem,
                Version = characterEquipment.Version,
            };
        }
    }
}
