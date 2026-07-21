import { ItemDto } from './item.dto';

export interface InventoryItemDto {
  item: ItemDto;
  ownedItemId: number;
  quantity: number;
}
