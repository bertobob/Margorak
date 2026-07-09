import { Component, computed, HostListener, inject } from '@angular/core';
import { GameStateService } from '../../core/services/game-state.service';
import { terrainImages } from './terrain-images';
import { PlayerMovementService } from './services/player-movement.service';

@Component({
  selector: 'app-map',
  standalone: true,
  imports: [],
  templateUrl: './map.html',
  styleUrl: './map.css',
})
export class Map {
  terrainImages = terrainImages;
  private gameState = inject(GameStateService);
  private playerMovement = inject(PlayerMovementService);

  playerPos = this.gameState.playerPos;

  currentMap = this.gameState.currentMap;

  visibleMap = computed(() => {
    const map = this.currentMap();

    if (!map?.tiles.length || !map.tiles[0]?.length) {
      return {
        tiles: [],
        playerViewX: -1,
        playerViewY: -1,
      };
    }

    const tiles = map.tiles;
    const sight = this.sightRange();

    const playerX = this.playerPos()[0];
    const playerY = this.playerPos()[1];

    const mapHeight = tiles.length;
    const mapWidth = tiles[0].length;

    const leftIndex = Math.max(0, Math.min(playerX - sight, mapWidth - sight * 2 - 1));
    const topIndex = Math.max(0, Math.min(playerY - sight, mapHeight - sight * 2 - 1));

    const rightIndex = Math.min(mapWidth, leftIndex + sight * 2 + 1);
    const bottomIndex = Math.min(mapHeight, topIndex + sight * 2 + 1);

    return {
      tiles: tiles.slice(topIndex, bottomIndex).map((row) => row.slice(leftIndex, rightIndex)),

      playerViewX: playerX - leftIndex,
      playerViewY: playerY - topIndex,
    };
  });

  sightRange = computed(() => {
    return this.currentMap()?.sightRange ?? 8;
  });

  constructor() {}

  @HostListener('window:keydown', ['$event'])
  handleKey(event: KeyboardEvent) {
    switch (event.key) {
      case 'ArrowUp':
        event.preventDefault();
        this.playerMovement.moveBy(0, -1);
        break;

      case 'ArrowDown':
        event.preventDefault();
        this.playerMovement.moveBy(0, 1);
        break;

      case 'ArrowLeft':
        event.preventDefault();
        this.playerMovement.moveBy(-1, 0);
        break;

      case 'ArrowRight':
        event.preventDefault();
        this.playerMovement.moveBy(1, 0);
        break;
    }
  }
}
