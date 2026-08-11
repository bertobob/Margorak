import { Component, inject } from '@angular/core';
import { GameStateService } from '../../core/services/game-state.service';
import { CombatService } from '../../core/services/combat.service';

@Component({
  selector: 'app-combat',
  imports: [],
  templateUrl: './combat.html',
  styleUrl: './combat.css',
})
export class Combat {
  private readonly gameState = inject(GameStateService);
  private readonly combatService = inject(CombatService);

  protected readonly character = this.gameState.activeCharacter;
  protected readonly activeCombat = this.combatService.activeCombat;

  protected hpPercent(currentHp: number, maxHp: number): number {
    if (maxHp <= 0) {
      return 0;
    }

    return Math.max(0, Math.min(100, (currentHp / maxHp) * 100));
  }

  protected endCombat(): void {
    this.combatService.clearCombat();
    this.gameState.endCombat();
  }
}
