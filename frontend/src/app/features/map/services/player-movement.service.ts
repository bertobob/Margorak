import { inject, Injectable } from '@angular/core';
import { GameStateService } from '../../../core/services/game-state.service';
import { CombatantHabitatService } from './combatant-habitat.service';
import { ApiService } from '../../../core/services/api-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PlayerMovementService {
  private gameState = inject(GameStateService);
  private apiService = inject(ApiService);
  private combatantHabitatService = inject(CombatantHabitatService);

  moveBy(xOffset: number, yOffset: number): void {
    const map = this.gameState.currentMap();

    if (!map) {
      return;
    }

    const [x, y] = this.gameState.playerPos();
    const nextPos = this.clampToMap(x + xOffset, y + yOffset);

    if (!this.isAccessible(nextPos.x, nextPos.y)) {
      return;
    }

    this.gameState.setPlayerPos(nextPos.x, nextPos.y);

    const terrainTypeId = map.tiles[nextPos.y][nextPos.x].terrainTypeId;
    const habitat = this.combatantHabitatService.findHabitatAt(
      this.gameState.playerPos(),
      terrainTypeId,
      this.gameState.combatantHabitats()
    );

    if (habitat) {
      console.log('habitat found ', habitat);
    }
  }

  public savePosition(): Observable<void> | null {
    const character = this.gameState.activeCharacter();
    const map = this.gameState.currentMap();
    const [locX, locY] = this.gameState.playerPos();

    if (!character || !map) {
      return null;
    }

    return this.apiService.updateCharacterPosition(character.id, map.id, locX, locY);
  }
  private clampToMap(x: number, y: number) {
    const map = this.gameState.currentMap();

    if (!map) {
      return { x: 0, y: 0 };
    }

    const maxX = map.tiles[0].length - 1;
    const maxY = map.tiles.length - 1;

    return {
      x: Math.max(0, Math.min(x, maxX)),
      y: Math.max(0, Math.min(y, maxY)),
    };
  }

  private isAccessible(x: number, y: number): boolean {
    const map = this.gameState.currentMap();

    return Number(map?.tiles[y]?.[x]?.accessible) === 1;
  }
}
