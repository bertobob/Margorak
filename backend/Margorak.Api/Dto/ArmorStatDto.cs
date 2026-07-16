using Margorak.Api.Models;

namespace Margorak.Api.Dto
{
    public class ArmorStatDto
    {
        public int ArmorValue { get; set; }
        public int EvasionValue { get; set; }        
        public EquipSlotDto EquipSlot { get; set; } = null!;
    }
}
