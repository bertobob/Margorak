import { computed, effect, inject, Injectable, signal } from '@angular/core';
import { MapDto } from '../../features/map/dto/map.dto';
import { CombatantHabitatDto } from '../../shared/dto/combatant-habitat.dto';
import { CharacterDto, CharacterStatsDto } from '../../features/character/dto/character.dto';
import { InventoryItemDto } from '../../shared/dto/inventory-item.dto';
import { ApiService } from './api-service';
import { Equipment, EquipmentSlot } from '../../features/equipment-panel/dto/equipment-panel.dto';
import { SaveCharacterDto } from '../../features/character/dto/save-character.dto';
import { LocationDto } from '../../features/character/dto/location.dto';
import { EquippedItemDto } from '../../features/character/dto/equipped-item.dto';
import { Observable } from 'rxjs';
import { LoadCharacterDto } from '../../features/character/dto/load-character.dto';
import { ShopDto } from '../../features/shop/dto/shop.dto';
import { MapInteractionDto } from '../../features/map/dto/map-interaction.dto';
import { HttpErrorResponse } from '@angular/common/http';
import { CombatService } from './combat.service';

@Injectable({
  providedIn: 'root',
})
export class GameStateService {
  private apiService = inject(ApiService);
  private combatService = inject(CombatService);
  private clientId = '';

  maps = signal<MapDto[]>([]);
  currentMapIndex = signal(0);
  errorMessage = signal<string | null>(null);
  characters = signal<CharacterDto[]>([]);
  activeCharacter = signal<CharacterDto | null>(null);
  activeCombat = signal<number | null>(null);
  activeEncounter = signal<CombatantHabitatDto | null>(null);
  currentInventory = signal<InventoryItemDto[]>([]);
  wealth = computed(() => this.activeCharacter()?.gold ?? 0);

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
  activeShop = signal<ShopDto | null>(null);
  activeShopInteractionId = signal<number | null>(null);
  shopActive = computed(() => this.activeShop() !== null);

  playerPos = signal<[number, number]>([30, 30]);
  combatantHabitats = signal<CombatantHabitatDto[]>([]);

  currentMap = computed(() => this.maps()[this.currentMapIndex()] ?? null);

  activeMapInteraction = computed(() => {
    const map = this.currentMap();
    const [x, y] = this.playerPos();
    const tileInteraction = map?.tiles[y]?.[x]?.mapInteraction ?? null;

    if (tileInteraction !== null) {
      return tileInteraction;
    }
    const activeEncounter = this.activeEncounter();
    if (activeEncounter !== null) {
      const encounterInteraction: MapInteractionDto = {
        type: 'encounter',
        description: 'attack ' + activeEncounter.combatantName,
        id: activeEncounter.combatantId,
      };

      return encounterInteraction;
    }
    return null;
  });

  interactionText = computed(() => this.activeMapInteraction()?.description ?? '');

  constructor() {
    effect(() => {
      const currentInteraction = this.activeMapInteraction();
      const activeShopInteractionId = this.activeShopInteractionId();

      if (
        activeShopInteractionId !== null &&
        (currentInteraction?.type !== 'shop' || currentInteraction.id !== activeShopInteractionId)
      ) {
        this.activeShop.set(null);
        this.activeShopInteractionId.set(null);
      }
    });
  }

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

    const characterStats: CharacterStatsDto = {
      strength: activeCharacter.strength,
      dexterity: activeCharacter.dexterity,
      intelligence: activeCharacter.intelligence,
      vitality: activeCharacter.vitality,
      statusPoints: activeCharacter.statusPoints,
      currentHp: activeCharacter.currentHp,
    };

    const character: SaveCharacterDto = {
      location: location,
      inventoryItems: this.currentInventory(),
      equippedItems: equippedItems,
      characterStats: characterStats,
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

  closeShop(): void {
    this.activeShop.set(null);
    this.activeShopInteractionId.set(null);
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
    this.activeShop.set(null);
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

  loadShop(shopInteractionId: number) {
    return this.apiService.loadShop(shopInteractionId);
  }

  endCombat(): void {
    this.activeCombat.set(null);
    this.apiService.endCombat(this.activeCharacter()!.id).subscribe();
  }

  loadCombatantHabitats(): void {
    const currentMap = this.currentMap();

    if (!currentMap) {
      return;
    }
    this.apiService.getCombatantHabitatsByMapId(currentMap.id).subscribe({
      next: (combatHabitats) => {
        this.setCombatantHabitats(combatHabitats);
      },
      error: (error: HttpErrorResponse) => {
        this.setErrorMessage('couldnt load combatantHabitats ' + error);
      },
    });
  }

  startCombat(combatantId: number): void {
    this.activeCombat.set(combatantId);
    this.combatService.loadCombatData(this.activeCharacter()!.id, combatantId);
  }
}
