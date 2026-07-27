import { inject, Injectable } from '@angular/core';
import { MapInteractionDto, MapInteractionHandler } from '../../dto/map-interaction.dto';
import { GameStateService } from '../../../../core/services/game-state.service';

@Injectable({
  providedIn: 'root',
})
export class ShopInteractionHandlerService implements MapInteractionHandler {
  readonly type = 'shop';
  private readonly gameState = inject(GameStateService);

  handle(interaction: MapInteractionDto): void {
    if (interaction.type !== this.type) {
      return;
    }
    this.gameState.loadShop(interaction.id).subscribe({
      next: (loadedShop) => {
        this.gameState.activeShop.set(loadedShop);
        this.gameState.activeShopInteractionId.set(interaction.id);
      },

      error: (error) => {
        console.error('Shop couldnt be loaded', error);
        this.gameState.setErrorMessage('Shop couldnt be loaded.');
      },
    });
  }
}
