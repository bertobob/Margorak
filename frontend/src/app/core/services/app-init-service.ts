import { inject, Injectable } from '@angular/core';
import { GameStateService } from './game-state.service';
import { ApiService } from './api-service';
import { ClientSessionService } from './client-session.service';
import { HttpErrorResponse } from '@angular/common/http';

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

    this.loadCharacters();
    this.loadMapData();
  }

  private loadCharacters(): void {
    this.apiService.loadCharacters().subscribe({
      next: (characters) => {
        this.gameState.setCharacters(characters);
      },
      error: (error: HttpErrorResponse) => {
        this.gameState.setErrorMessage('couldnt load Character' + error);
      },
    });
  }

  private loadMapData(): void {
    this.apiService.loadMapData().subscribe({
      next: (maps) => {
        this.gameState.setMaps(maps);
        this.loadCombatantHabitats();
      },
      error: (error: HttpErrorResponse) => {
        this.gameState.setErrorMessage('couldnt load map data' + error);
      },
    });
  }

  private loadCombatantHabitats(): void {
    const currentMap = this.gameState.currentMap();

    if (!currentMap) {
      return;
    }
    this.apiService.loadCombatantHabitats(currentMap.id).subscribe({
      next: (combatHabitats) => {
        this.gameState.setCombatantHabitats(combatHabitats);
      },
      error: (error: HttpErrorResponse) => {
        this.gameState.setErrorMessage('couldnt load combatantHabitats ' + error);
      },
    });
  }
}
