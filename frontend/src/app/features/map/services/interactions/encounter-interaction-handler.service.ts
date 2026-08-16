import { inject, Injectable } from '@angular/core';
import { MapInteractionDto, MapInteractionHandler } from '../../dto/map-interaction.dto';
import { GameStateService } from '../../../../core/services/game-state.service';

@Injectable({
  providedIn: 'root',
})
export class EncounterInteractionHandlerService implements MapInteractionHandler {
  readonly type = 'encounter';
  private readonly gameStateService = inject(GameStateService);

  handle(interaction: MapInteractionDto): void {
    if (interaction.type !== this.type) {
      return;
    }
    this.gameStateService.saveCharacter()?.subscribe();

    this.gameStateService.startCombat(interaction.id);
  }
}
