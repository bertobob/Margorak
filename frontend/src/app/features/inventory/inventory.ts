import { Component, inject } from '@angular/core';
import { GameStateService } from '../../core/services/game-state.service';
import { ItemDto, ItemRequirementDto } from '../../shared/dto/item.dto';
import { allRequirementsMet } from '../../shared/utils/requirement-checks';
import { EquipmentService } from '../../core/services/equipment.service';
import { InventoryItemDto } from '../../shared/dto/inventory-item.dto';
import { ItemDetails } from '../../shared/components/item-details/item-details';
import { ItemListEntry } from '../../shared/components/item-list-entry/item-list-entry';
import { TradeItemRequestDto } from '../shop/dto/shop.dto';
import { ApiService } from '../../core/services/api-service';

@Component({
  selector: 'app-inventory',
  imports: [ItemDetails, ItemListEntry],
  templateUrl: './inventory.html',
  styleUrl: './inventory.css',
})
export class Inventory {
  private gameState = inject(GameStateService);
  private equipmentService = inject(EquipmentService);
  private api = inject(ApiService);
  protected inventory = this.gameState.currentInventory;
  protected wealth = this.gameState.wealth;
  protected activeShop = this.gameState.activeShop;
  private activeShopInteractionId = this.gameState.activeShopInteractionId;
  protected shopActive = this.gameState.shopActive;

  protected onEquipClicked(inventoryItem: InventoryItemDto): void {
    this.equipmentService.onEquipClicked(inventoryItem);
  }

  getSellPrice(item: ItemDto): number {
    const shop = this.activeShop();

    if (shop === null || shop.greed <= 0) {
      return 0;
    }

    return Math.trunc(item.value / shop.greed);
  }

  protected canSell(): boolean {
    const shop = this.activeShop();
    return shop !== null && shop.greed > 0;
  }

  protected isAllRequirementsMet(itemRequirements: ItemRequirementDto[]): boolean {
    const character = this.gameState.activeCharacter();

    if (!character) {
      return false;
    }
    return allRequirementsMet(itemRequirements, character);
  }

  onSellClicked(item: ItemDto) {
    const character = this.gameState.activeCharacter();
    const shopInteractionId = this.activeShopInteractionId();

    if (character === null || shopInteractionId === null) {
      return;
    }
    const request: TradeItemRequestDto = {
      characterId: character.id,
      itemId: item.id,
    };

    this.api.sell(request, shopInteractionId).subscribe({
      next: (response) => {
        this.gameState.activeCharacter.update((currentCharacter) =>
          currentCharacter ? { ...currentCharacter, gold: response.remainingGold } : null
        );
        this.gameState.currentInventory.set(response.inventoryItems);
      },
    });
  }
}
