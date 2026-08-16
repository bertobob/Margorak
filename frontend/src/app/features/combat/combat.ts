import { Component, computed, effect, ElementRef, inject, viewChild } from '@angular/core';
import { GameStateService } from '../../core/services/game-state.service';
import { CombatService } from '../../core/services/combat.service';
import { HealthBar } from '../../shared/components/health-bar/health-bar';

@Component({
  selector: 'app-combat',
  imports: [HealthBar],
  templateUrl: './combat.html',
  styleUrl: './combat.css',
})
export class Combat {
  private readonly gameStateService = inject(GameStateService);
  private readonly combatService = inject(CombatService);

  private readonly combatLog = viewChild<ElementRef<HTMLElement>>('combatLog');

  protected readonly character = this.gameStateService.activeCharacter;
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
  protected endCombat(): void {
    this.combatService.clearCombat();
    this.gameStateService.endCombat();
  }

  protected attack(): void {
    const character = this.character();

    if (character === null) {
      return;
    }

    this.combatService.attack(character.id);
  }

  protected returnToMap(): void {
    this.gameStateService.collectLoot();
  }

  protected respawn(): void {
    this.gameStateService.respawnCharacter();
  }
}
