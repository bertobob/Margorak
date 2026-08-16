import { inject, Injectable } from '@angular/core';
import { GameStateService } from './game-state.service';
import { ApiService } from './api-service';
import { ClientSessionService } from './client-session.service';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AppInitService {
  private readonly gameStateService = inject(GameStateService);
  private readonly apiService = inject(ApiService);
  private readonly clientSessionService = inject(ClientSessionService);

  init(): void {
    const clientId = this.clientSessionService.getOrCreateClientId();
    this.gameStateService.setClientId(clientId);

    this.loadCharacters();
    this.loadMapData();
  }

  private loadCharacters(): void {
    this.apiService.getCharacters().subscribe({
      next: (characters) => {
        this.gameStateService.setCharacters(characters);
      },
      error: (error: HttpErrorResponse) => {
        this.gameStateService.setErrorMessage('couldnt load Character' + error);
      },
    });
  }

  private loadMapData(): void {
    this.apiService.getMapData().subscribe({
      next: (maps) => {
        this.gameStateService.setMaps(maps);
      },
      error: (error: HttpErrorResponse) => {
        this.gameStateService.setErrorMessage('couldnt load map data' + error);
      },
    });
  }
}
