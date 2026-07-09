import { computed, Injectable, signal } from '@angular/core';
import { MapDto } from '../../features/map/dto/map.dto';
import { CombatantHabitatDto } from '../../shared/dto/combatant-habitat.dto';

@Injectable({
  providedIn: 'root',
})
export class GameStateService {
  private clientId = '';

  maps = signal<MapDto[]>([]);
  currentMapIndex = signal(0);
  playerPos = signal<[number, number]>([30, 30]);
  combatantHabitats = signal<CombatantHabitatDto[]>([]);

  currentMap = computed(() => this.maps()[this.currentMapIndex()] ?? null);

  activeMapInteraction = computed(() => {
    const map = this.currentMap();
    const [x, y] = this.playerPos();

    return map?.tiles[y]?.[x]?.mapInteraction ?? null;
  });

  interactionText = computed(() => this.activeMapInteraction()?.description ?? '');

  setClientId(clientId: string): void {
    this.clientId = clientId;
  }

  getClientId(): string {
    return this.clientId;
  }

  setMaps(maps: MapDto[]): void {
    this.maps.set(maps);
  }

  setCombatantHabitats(combatantHabitats: CombatantHabitatDto[]): void {
    this.combatantHabitats.set(combatantHabitats);
  }

  setPlayerPos(x: number, y: number): void {
    this.playerPos.set([x, y]);
  }
}
