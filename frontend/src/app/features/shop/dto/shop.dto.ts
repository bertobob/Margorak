import { InventoryItemDto } from '../../../shared/dto/inventory-item.dto';
import { ItemDto } from '../../../shared/dto/item.dto';

export interface ShopDto {
  greed: number;
  shopItems: ItemDto[];
}

export interface TradeItemRequestDto {
  itemId: number;
  characterId: number;
}

export interface TradeItemResponseDto {
  remainingGold: number;
  inventoryItems: InventoryItemDto[];
}
