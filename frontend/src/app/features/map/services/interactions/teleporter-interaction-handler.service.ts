import { inject, Injectable } from '@angular/core';
import { MapInteractionDto, MapInteractionHandler } from '../../dto/map-interaction.dto';
import { GameStateService } from '../../../../core/services/game-state.service';

@Injectable({
  providedIn: 'root',
})
export class TeleporterInteractionHandler implements MapInteractionHandler {
  private gameStateService = inject(GameStateService);
  type: 'teleporter' = 'teleporter';
  handle(interaction: MapInteractionDto): void {
    if (interaction.type !== 'teleporter') {
      return;
    }
    const targetMapIndex = this.gameStateService
      .maps()
      .findIndex((map) => map.id === interaction.destinationMapId);

    if (targetMapIndex === -1) {
      return;
    }

    this.gameStateService.currentMapIndex.set(targetMapIndex);
    this.gameStateService.setPlayerPos(interaction.destinationLocX, interaction.destinationLocY);
  }
}
