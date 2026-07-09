import { Component, inject } from '@angular/core';
import { GameStateService } from '../../core/services/game-state.service';
import { MapInteractionDispatcherService } from '../map/services/interactions/map-interaction-dispatcher.service';

@Component({
  selector: 'app-interaction-bar',
  imports: [],
  templateUrl: './interaction-bar.html',
  styleUrl: './interaction-bar.css',
})
export class InteractionBar {
  private gameStateService = inject(GameStateService);
  private mapInteractionDispatcher = inject(MapInteractionDispatcherService);
  interactionText = this.gameStateService.interactionText;

  handleInteractionClick(): void {
    const interaction = this.gameStateService.activeMapInteraction();

    if (!interaction) {
      return;
    }

    this.mapInteractionDispatcher.handle(interaction);
  }
}
