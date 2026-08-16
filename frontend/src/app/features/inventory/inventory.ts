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
  private readonly gameStateService = inject(GameStateService);
  private readonly equipmentService = inject(EquipmentService);
  private readonly apiService = inject(ApiService);
  protected inventory = this.gameStateService.currentInventory;
  protected wealth = this.gameStateService.wealth;
  protected activeShop = this.gameStateService.activeShop;
  private activeShopInteractionId = this.gameStateService.activeShopInteractionId;
  protected shopActive = this.gameStateService.shopActive;

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
    const character = this.gameStateService.activeCharacter();

    if (!character) {
      return false;
    }
    return allRequirementsMet(itemRequirements, character);
  }

  onSellClicked(item: ItemDto) {
    const character = this.gameStateService.activeCharacter();
    const shopInteractionId = this.activeShopInteractionId();

    if (character === null || shopInteractionId === null) {
      return;
    }
    const request: TradeItemRequestDto = {
      characterId: character.id,
      itemId: item.id,
    };

    this.apiService.sell(request, shopInteractionId).subscribe({
      next: (response) => {
        this.gameStateService.activeCharacter.update((currentCharacter) =>
          currentCharacter ? { ...currentCharacter, gold: response.remainingGold } : null
        );
        this.gameStateService.currentInventory.set(response.inventoryItems);
      },
    });
  }
}
