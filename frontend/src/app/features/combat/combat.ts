import { Component, computed, effect, ElementRef, inject, viewChild } from '@angular/core';
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

  private readonly combatLog = viewChild<ElementRef<HTMLElement>>('combatLog');

  protected readonly character = this.gameState.activeCharacter;
  protected readonly activeCombat = this.combatService.activeCombat;

  constructor() {
    effect(() => {
      this.activeCombat()?.combatLogs;

      requestAnimationFrame(() => {
        const element = this.combatLog()?.nativeElement;

        if (element) {
          element.scrollTop = element.scrollHeight;
        }
      });
    });
  }
  protected readonly characterDefeated = computed(() => {
    const combat = this.activeCombat();

    return combat?.battleOver === true && combat.currentCharacterHp <= 0;
  });

  protected readonly combatantDefeated = computed(() => {
    const combat = this.activeCombat();

    return combat?.battleOver === true && combat.currentCombatantHp <= 0;
  });
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

  protected attack(): void {
    const character = this.character();

    if (character === null) {
      return;
    }

    this.combatService.attack(character.id);
  }

  protected returnToMap(): void {
    this.gameState.collectLoot();
  }

  protected respawn(): void {
    this.gameState.respawnCharacter();
  }
}
