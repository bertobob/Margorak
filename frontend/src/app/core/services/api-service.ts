import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../config/config';
import { MapDto } from '../../features/map/dto/map.dto';
import { CombatantHabitatDto } from '../../shared/dto/combatant-habitat.dto';
import {
  CharacterClassDto,
  CharacterDto,
  CharacterRaceDto,
} from '../../features/character/dto/character.dto';
import { CreateCharacterDto } from '../../features/character/dto/create-character.dto';
import { InventoryItemDto } from '../../shared/dto/inventory-item.dto';
import { ItemDto } from '../../shared/dto/item.dto';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private http = inject(HttpClient);
  private apiBaseUrl = environment.apiBaseUrl;

  saveUser(clientId: string) {
    //return this.http.post<void>(`${this.apiBaseUrl}/api/client-data/user`,{clientId})
  }

  getCharacters() {
    return this.http.get<CharacterDto[]>(`${this.apiBaseUrl}/api/characters`);
  }

  getCharacterById(characterId: number) {
    return this.http.get<CharacterDto>(`${this.apiBaseUrl}/api/characters/${characterId}`);
  }

  getCharacterRaces() {
    return this.http.get<CharacterRaceDto[]>(`${this.apiBaseUrl}/api/characters/options/races`);
  }

  getCharacterClasses() {
    return this.http.get<CharacterClassDto[]>(`${this.apiBaseUrl}/api/characters/options/classes`);
  }

  createCharacter(character: CreateCharacterDto) {
    return this.http.post<CharacterDto>(`${this.apiBaseUrl}/api/characters`, character);
  }

  updateCharacterPosition(characterId: number, mapId: number, locX: number, locY: number) {
    return this.http.patch<void>(`${this.apiBaseUrl}/api/characters/${characterId}/position`, {
      mapId,
      locX,
      locY,
    });
  }

  getMapData() {
    return this.http.get<MapDto[]>(`${this.apiBaseUrl}/api/maps`);
  }

  getCombatantHabitatsByMapId(mapId: number) {
    return this.http.get<CombatantHabitatDto[]>(
      `${this.apiBaseUrl}/api/maps/${mapId}/combatant-habitats`
    );
  }

  getItemById(itemId: number) {
    return this.http.get<ItemDto>(`${this.apiBaseUrl}/api/items/${itemId}`);
  }

  getItemsByCharacterId(characterId: number) {
    return this.http.get<InventoryItemDto[]>(
      `${this.apiBaseUrl}/api/characters/${characterId}/inventory`
    );
  }
}
