import { inject, Injectable } from '@angular/core';
import { GameStateService } from '../../../core/services/game-state.service';
import { CombatantHabitatService } from './combatant-habitat.service';

@Injectable({
  providedIn: 'root',
})
export class PlayerMovementService {
  private readonly gameStateService = inject(GameStateService);
  private readonly combatantHabitatService = inject(CombatantHabitatService);

  moveBy(xOffset: number, yOffset: number): void {
    const map = this.gameStateService.currentMap();

    if (!map) {
      return;
    }

    const [x, y] = this.gameStateService.playerPos();
    const nextPos = this.clampToMap(x + xOffset, y + yOffset);

    if (!this.isAccessible(nextPos.x, nextPos.y)) {
      return;
    }
    this.gameStateService.setPlayerPos(nextPos.x, nextPos.y);

    const terrainTypeId = map.tiles[nextPos.y][nextPos.x].terrainTypeId;
    const habitat = this.combatantHabitatService.checkForEncounter(
      this.gameStateService.playerPos(),
      terrainTypeId,
      this.gameStateService.combatantHabitats()
    );

    this.gameStateService.activeEncounter.set(habitat);
  }

  private clampToMap(x: number, y: number) {
    const map = this.gameStateService.currentMap();

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
    const map = this.gameStateService.currentMap();

    return Number(map?.tiles[y]?.[x]?.accessible) === 1;
  }
}
