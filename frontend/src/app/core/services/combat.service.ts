import { inject, Injectable, signal } from '@angular/core';
import { ApiService } from './api-service';
import { ActiveCombatDto } from '../../features/combat/dto/combat.dto';

@Injectable({
  providedIn: 'root',
})
export class CombatService {
  private readonly apiService = inject(ApiService);
  private readonly activeCombatState = signal<ActiveCombatDto | null>(null);

  readonly activeCombat = this.activeCombatState.asReadonly();

  loadCombatData(characterId: number, combatantId: number): void {
    this.apiService.startCombat(characterId, combatantId).subscribe({
      next: (activeCombat) => {
        console.log(activeCombat);
        this.activeCombatState.set(activeCombat);
      },
      error: (error) => {
        console.error('Couldnt load active combat', error);
        this.activeCombatState.set(null);
      },
    });
  }
  clearCombat(): void {
    this.activeCombatState.set(null);
  }
}
