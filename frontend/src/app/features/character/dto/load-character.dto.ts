import { InventoryItemDto } from '../../../shared/dto/inventory-item.dto';
import { CharacterDto } from './character.dto';
import { EquippedItemDto } from './equipped-item.dto';

export interface LoadCharacterDto {
  character: CharacterDto;
  inventoryItems: InventoryItemDto[];
  equippedItems: EquippedItemDto[];
}
