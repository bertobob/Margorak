namespace Margorak.Api.Dto
{
    public class LoadCharacterDto
    {
        public CharacterDto Character { get; set; } = null!;
        public List<InventoryItemDto> InventoryItems { get; set; } = [];
        public EquippedItemDto[] EquippedItems { get; set; } = [];
    }
}
