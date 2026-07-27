import { Component, effect, inject, signal } from '@angular/core';
import { InteractionBar } from '../interaction-bar/interaction-bar';
import { Inventory } from '../inventory/inventory';
import { Map } from '../map/map';
import { Character } from '../character/character';
import { CharacterSelection } from '../character-selection/character-selection';
import { GameStateService } from '../../core/services/game-state.service';
import { Shop } from '../shop/shop';

@Component({
  selector: 'app-navigation-bar',
  imports: [InteractionBar, Inventory, Map, Character, CharacterSelection, Shop],
  templateUrl: './navigation-bar.html',
  styleUrl: './navigation-bar.css',
})
export class NavigationBar {
  protected readonly gameState = inject(GameStateService);
  protected shopActive = this.gameState.shopActive;
  protected activeView = signal<'character-selection' | 'map' | 'inventory' | 'character' | 'shop'>(
    'character-selection'
  );

  constructor() {
    effect(() => {
      if (this.gameState.activeShop()) {
        this.activeView.set('shop');
      }
    });
  }

  protected showCharacterSelection(): void {
    this.activeView.set('character-selection');
  }

  protected showMap(): void {
    this.activeView.set('map');
  }

  protected showInventory(): void {
    this.activeView.set('inventory');
  }

  protected showCharacter(): void {
    this.activeView.set('character');
  }

  protected showShop(): void {
    this.activeView.set('shop');
  }
}
