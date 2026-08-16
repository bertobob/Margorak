import { Component, inject } from '@angular/core';
import { GameStateService } from '../../core/services/game-state.service';
import { ItemDetails } from '../../shared/components/item-details/item-details';
import { ItemListEntry } from '../../shared/components/item-list-entry/item-list-entry';
import { ItemDto } from '../../shared/dto/item.dto';
import { ApiService } from '../../core/services/api-service';
import { TradeItemRequestDto } from './dto/shop.dto';

@Component({
  selector: 'app-shop',
  imports: [ItemDetails, ItemListEntry],
  templateUrl: './shop.html',
  styleUrl: './shop.css',
})
export class Shop {
  private readonly gameStateService = inject(GameStateService);
  private readonly apiService = inject(ApiService);
  protected activeShop = this.gameStateService.activeShop;
  protected activeShopInteractionId = this.gameStateService.activeShopInteractionId;
  protected shopActive = this.gameStateService.shopActive;
  protected wealth = this.gameStateService.wealth;

  getBuyPrice(item: ItemDto): number {
    const shop = this.activeShop();

    if (shop === null) {
      return 0;
    }

    return Math.trunc(item.value * shop.greed);
  }

  isAffordable(item: ItemDto): boolean {
    const character = this.gameStateService.activeCharacter();

    if (character === null) {
      return false;
    }

    return this.getBuyPrice(item) <= character.gold;
  }

  buy(item: ItemDto): void {
    const character = this.gameStateService.activeCharacter();
    const shopInteractionId = this.activeShopInteractionId();

    if (character === null || shopInteractionId === null) {
      return;
    }
    const request: TradeItemRequestDto = {
      characterId: character.id,
      itemId: item.id,
    };

    this.apiService.buy(request, shopInteractionId).subscribe({
      next: (response) => {
        this.gameStateService.currentInventory.set(response.inventoryItems);
        this.gameStateService.activeCharacter.update((currentCharacter) =>
          currentCharacter ? { ...currentCharacter, gold: response.remainingGold } : null
        );
      },
    });
  }
}
