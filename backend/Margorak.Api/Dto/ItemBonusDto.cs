using Margorak.Api.Models;

namespace Margorak.Api.Dto
{
    public class ItemBonusDto
    {
        public BonusTypeDto BonusType { get; set; } = null!;
        public int Value { get; set; }

    }
}
