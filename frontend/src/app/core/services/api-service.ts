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
import { ItemDto } from '../../shared/dto/item.dto';
import { SaveCharacterDto } from '../../features/character/dto/save-character.dto';
import { LoadCharacterDto } from '../../features/character/dto/load-character.dto';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private http = inject(HttpClient);
  private apiBaseUrl = environment.apiBaseUrl;

  saveCharacter(characterId: number, saveCharacterDto: SaveCharacterDto) {
    return this.http.put<void>(
      `${this.apiBaseUrl}/api/characters/${characterId}/save`,
      saveCharacterDto
    );
  }

  getCharacters() {
    return this.http.get<CharacterDto[]>(`${this.apiBaseUrl}/api/characters`);
  }

  loadCharacter(characterId: number) {
    return this.http.get<LoadCharacterDto>(`${this.apiBaseUrl}/api/characters/${characterId}/load`);
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
}
