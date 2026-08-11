import { inject, Injectable } from '@angular/core';
import { MapInteractionDto, MapInteractionHandler } from '../../dto/map-interaction.dto';
import { GameStateService } from '../../../../core/services/game-state.service';
import { CombatService } from '../../../../core/services/combat.service';

@Injectable({
  providedIn: 'root',
})
export class EncounterInteractionHandlerService implements MapInteractionHandler {
  readonly type = 'encounter';
  private readonly gameState = inject(GameStateService);
  private readonly combat = inject(CombatService);

  handle(interaction: MapInteractionDto): void {
    if (interaction.type !== this.type) {
      return;
    }

    this.gameState.startCombat(interaction.id);
  }
}
