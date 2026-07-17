import { ItemCategoryDto } from './item.dto';

export interface InventoryItemDto {
  itemId: number;
  name: string;
  category: ItemCategoryDto;
  quantity: number;
}
