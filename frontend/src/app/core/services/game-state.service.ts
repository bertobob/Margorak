import { computed, inject, Injectable, signal } from '@angular/core';
import { MapDto } from '../../features/map/dto/map.dto';
import { CombatantHabitatDto } from '../../shared/dto/combatant-habitat.dto';
import { CharacterDto } from '../../features/character/dto/character.dto';
import { InventoryItemDto } from '../../shared/dto/inventory-item.dto';
import { ApiService } from './api-service';

@Injectable({
  providedIn: 'root',
})
export class GameStateService {
  private apiService = inject(ApiService);
  private clientId = '';

  maps = signal<MapDto[]>([]);
  currentMapIndex = signal(0);
  errorMessage = signal<string | null>(null);
  characters = signal<CharacterDto[]>([]);
  activeCharacter = signal<CharacterDto | null>(null);
  currentInventory = signal<InventoryItemDto[]>([]);

  playerPos = signal<[number, number]>([30, 30]);
  combatantHabitats = signal<CombatantHabitatDto[]>([]);

  currentMap = computed(() => this.maps()[this.currentMapIndex()] ?? null);

  activeMapInteraction = computed(() => {
    const map = this.currentMap();
    const [x, y] = this.playerPos();

    return map?.tiles[y]?.[x]?.mapInteraction ?? null;
  });

  interactionText = computed(() => this.activeMapInteraction()?.description ?? '');

  loadCurrentInventory(): void {
    const character = this.activeCharacter();

    if (!character) {
      this.currentInventory.set([]);
      return;
    }

    this.apiService.getItemsByCharacterId(character.id).subscribe({
      next: (items) => {
        this.currentInventory.set(items);
      },
      error: () => {
        this.errorMessage.set("Couldn't load inventory.");
        this.currentInventory.set([]);
      },
    });
  }
  setClientId(clientId: string): void {
    this.clientId = clientId;
  }

  getClientId(): string {
    return this.clientId;
  }

  setCharacters(characters: CharacterDto[]): void {
    this.characters.set(characters);
  }

  addCharacter(character: CharacterDto): void {
    this.characters.update((characters) => [...characters, character]);
  }

  setActiveCharacter(character: CharacterDto): void {
    this.activeCharacter.set(character);
    this.currentMapIndex.set(
      Math.max(
        0,
        this.maps().findIndex((map) => map.id === character.currentMapId)
      )
    );
    this.setPlayerPos(character.locX, character.locY);
    this.loadCurrentInventory();
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

  setErrorMessage(message: string) {
    this.errorMessage.set(message);
  }

  clearErrorMessage(): void {
    this.errorMessage.set(null);
  }
}
