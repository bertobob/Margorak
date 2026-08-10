import { InventoryItemDto } from '../../../shared/dto/inventory-item.dto';
import { CharacterStatsDto } from './character.dto';
import { EquippedItemDto } from './equipped-item.dto';
import { LocationDto } from './location.dto';

export interface SaveCharacterDto {
  location: LocationDto;
  equippedItems: EquippedItemDto[];
  inventoryItems: InventoryItemDto[];
  characterStats: CharacterStatsDto;
}
