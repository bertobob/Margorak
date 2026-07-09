import { inject, Injectable } from '@angular/core';
import { GameStateService } from './game-state.service';
import { ApiService } from './api-service';
import { ClientSessionService } from './client-session.service';

@Injectable({
  providedIn: 'root',
})
export class AppInitService {
  private gameState = inject(GameStateService);
  private apiService = inject(ApiService);
  private clientSession = inject(ClientSessionService);

  init(): void {
    const clientId = this.clientSession.getOrCreateClientId();
    this.gameState.setClientId(clientId);

    this.loadMapData();
  }

  private loadMapData(): void {
    this.apiService.loadMapData().subscribe((maps) => {
      this.gameState.setMaps(maps);

      const currentMap = this.gameState.currentMap();

      if (!currentMap) {
        return;
      }

      this.apiService.loadCombatantHabitats(currentMap.id).subscribe((combatantHabitats) => {
        this.gameState.setCombatantHabitats(combatantHabitats);
      });
    });
  }
}
