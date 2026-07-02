import { computed, Injectable, signal } from '@angular/core';
import { ApiService } from './api-service';
import { MapDto } from '../../features/map/map.dto';

@Injectable({
  providedIn: 'root',
})
export class DataStorageService {
  constructor(private api: ApiService) {}

  private clientId = '';

  maps = signal<MapDto[]>([]);
  currentMapIndex = signal(1);
  playerPos = signal<[number, number]>([1, 1]);

  currentMap = computed(() => this.maps()[this.currentMapIndex()]);
  activeMapInteraction = computed(() => {
    const [x, y] = this.playerPos()
    return this.maps()[this.currentMapIndex()]
      ?.tiles[y]?.[x]?.mapInteraction ?? null;
  });
  setPlayerPos(x: number, y: number): void {    
    this.playerPos.set([x, y]);
  }

  updatePlayerPos(xOffset: number, yOffset: number): void {
    const [x, y] = this.playerPos();

    const nextPos = this.clampToMap(x + xOffset, y + yOffset);

    if (!this.isAccessible(nextPos.x, nextPos.y)) {
      return;
    }

    this.playerPos.set([nextPos.x, nextPos.y]);
    const interaction = this.activeMapInteraction();
    
  }

  private clampToMap(x: number, y: number) {
    const map = this.currentMap();
    const maxX = map.tiles[0].length - 1;
    const maxY = map.tiles.length - 1;

    return {
      x: Math.max(0, Math.min(x, maxX)),
      y: Math.max(0, Math.min(y, maxY)),
    };
  }

  private isAccessible(x: number, y: number): boolean {
    return this.currentMap().tiles[y][x].accessible==1;
  }

  setClientId(clientId: string): void {
    this.clientId = clientId;
  }

  getClientId(): string {
    return this.clientId;
  }

  setLocalStorageItem(key: string, value: string): void {
    localStorage.setItem(key, value);
  }

  getLocalStorageItem(key: string): string | null {
    return localStorage.getItem(key);
  }

  saveUser(clientId: string): void {
    // this.api.saveUser(clientId).subscribe();
  }

  loadMapData(): void {
  this.api.loadMapData().subscribe(maps => {
    console.log(maps);
    this.maps.set(maps);
  });
}
}
