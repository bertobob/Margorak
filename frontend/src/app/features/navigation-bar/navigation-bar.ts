import { Component, effect, inject, signal } from '@angular/core';
import { InteractionBar } from '../interaction-bar/interaction-bar';
import { Inventory } from '../inventory/inventory';
import { Map } from '../map/map';
import { Character } from '../character/character';
import { CharacterSelection } from '../character-selection/character-selection';
import { GameStateService } from '../../core/services/game-state.service';
import { Shop } from '../shop/shop';
import { Combat } from '../combat/combat';

@Component({
  selector: 'app-navigation-bar',
  imports: [InteractionBar, Inventory, Map, Character, CharacterSelection, Shop, Combat],
  templateUrl: './navigation-bar.html',
  styleUrl: './navigation-bar.css',
})
export class NavigationBar {
  protected readonly gameState = inject(GameStateService);
  protected activeView = signal<
    'character-selection' | 'map' | 'inventory' | 'character' | 'shop' | 'combat'
  >('character-selection');

  constructor() {
    effect(() => {
      const activeCombat = this.gameState.activeCombat();

      if (activeCombat !== null) {
        this.activeView.set('combat');
        return;
      }

      if (this.activeView() === 'combat') {
        this.activeView.set('map');
      }
    });

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
    this.gameState.closeShop();
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
