import { computed, inject, Injectable, signal } from '@angular/core';
import { MapDto } from '../../features/map/dto/map.dto';
import { CombatantHabitatDto } from '../../shared/dto/combatant-habitat.dto';
import { CharacterDto } from '../../features/character/dto/character.dto';
import { InventoryItemDto } from '../../shared/dto/inventory-item.dto';
import { ApiService } from './api-service';
import { Equipment, EquipmentSlot } from '../../features/equipment-panel/dto/equipment-panel.dto';
import { SaveCharacterDto } from '../../features/character/dto/save-character.dto';
import { LocationDto } from '../../features/character/dto/location.dto';
import { EquippedItemDto } from '../../features/character/dto/equipped-item.dto';
import { Observable } from 'rxjs';
import { LoadCharacterDto } from '../../features/character/dto/load-character.dto';

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
  equipment = signal<Equipment>({
    Helmet: null,
    Chest: null,
    Legs: null,
    Gloves: null,
    Boots: null,
    Weapon: null,
    Shield: null,
    Ring: null,
    Amulet: null,
  });

  playerPos = signal<[number, number]>([30, 30]);
  combatantHabitats = signal<CombatantHabitatDto[]>([]);

  currentMap = computed(() => this.maps()[this.currentMapIndex()] ?? null);

  activeMapInteraction = computed(() => {
    const map = this.currentMap();
    const [x, y] = this.playerPos();

    return map?.tiles[y]?.[x]?.mapInteraction ?? null;
  });

  interactionText = computed(() => this.activeMapInteraction()?.description ?? '');

  public saveCharacter(): Observable<void> | null {
    const activeCharacter = this.activeCharacter();
    const currentMap = this.currentMap();

    if (!activeCharacter || !currentMap) {
      return null;
    }

    const location: LocationDto = {
      mapId: currentMap.id,
      locX: this.playerPos()[0],
      locY: this.playerPos()[1],
    };

    const equippedItems: EquippedItemDto[] = [];

    Object.values(this.equipment()).forEach((item) => {
      const equipSlotId = item?.item.itemCategory.equipSlot?.id;

      if (item !== null && equipSlotId !== undefined) {
        equippedItems.push({
          ownedItemId: item.ownedItemId,
          equipSlotId,
        });
      }
    });

    const character: SaveCharacterDto = {
      location: location,
      inventoryItems: this.currentInventory(),
      equippedItems: equippedItems,
    };
    return this.apiService.saveCharacter(activeCharacter.id, character);
  }

  private setInventoryAndEquipment(
    ownedItems: InventoryItemDto[],
    equippedItems: EquippedItemDto[]
  ): void {
    const equippedIds = new Set(equippedItems.map((item) => item.ownedItemId));
    const equipment = this.createEmptyEquipment();

    for (const equippedItem of equippedItems) {
      const inventoryItem = ownedItems.find(
        (item) => item.ownedItemId === equippedItem.ownedItemId
      );
      const slot = inventoryItem?.item.itemCategory.equipSlot?.name as EquipmentSlot | undefined;

      if (inventoryItem && slot && slot in equipment) {
        equipment[slot] = inventoryItem;
      }
    }

    this.equipment.set(equipment);
    this.currentInventory.set(ownedItems.filter((item) => !equippedIds.has(item.ownedItemId)));
  }

  private createEmptyEquipment(): Equipment {
    return {
      Helmet: null,
      Chest: null,
      Legs: null,
      Gloves: null,
      Boots: null,
      Weapon: null,
      Shield: null,
      Ring: null,
      Amulet: null,
    };
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

  setLoadedCharacter(loadedCharacter: LoadCharacterDto): void {
    const character = loadedCharacter.character;
    this.activeCharacter.set(character);
    this.currentMapIndex.set(
      Math.max(
        0,
        this.maps().findIndex((map) => map.id === character.currentMapId)
      )
    );
    this.setPlayerPos(character.locX, character.locY);
    this.setInventoryAndEquipment(loadedCharacter.inventoryItems, loadedCharacter.equippedItems);
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

  removeInventoryItem(ownedItemID: number) {
    this.currentInventory.update((items) =>
      items.filter((item) => item.ownedItemId !== ownedItemID)
    );
  }

  addInventoryItem(inventoryItem: InventoryItemDto): void {
    this.currentInventory.update((items) => [...items, inventoryItem]);
  }
}
