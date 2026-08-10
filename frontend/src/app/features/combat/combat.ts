import { Component, inject } from '@angular/core';
import { GameStateService } from '../../core/services/game-state.service';

@Component({
  selector: 'app-combat',
  imports: [],
  templateUrl: './combat.html',
  styleUrl: './combat.css',
})
export class Combat {
  private readonly gameState = inject(GameStateService);

  protected endCombat(): void {
    this.gameState.endCombat();
  }
}
