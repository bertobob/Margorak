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

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private http = inject(HttpClient);
  private apiBaseUrl = environment.apiBaseUrl;

  saveUser(clientId: string) {
    //return this.http.post<void>(`${this.apiBaseUrl}/api/client-data/user`,{clientId})
  }

  loadCharacters() {
    return this.http.get<CharacterDto[]>(`${this.apiBaseUrl}/api/characters`);
  }

  loadCharacter(characterId: number) {
    return this.http.get<CharacterDto>(`${this.apiBaseUrl}/api/characters/${characterId}`);
  }

  loadCharacterRaces() {
    return this.http.get<CharacterRaceDto[]>(`${this.apiBaseUrl}/api/characters/options/races`);
  }

  loadCharacterClasses() {
    return this.http.get<CharacterClassDto[]>(`${this.apiBaseUrl}/api/characters/options/classes`);
  }

  createCharacter(character: CreateCharacterDto) {
    return this.http.post<CharacterDto>(`${this.apiBaseUrl}/api/characters`, character);
  }

  updateCharacterPosition(characterId: number, mapId: number, locX: number, locY: number) {
    return this.http.patch<void>(
      `${this.apiBaseUrl}/api/characters/${characterId}/position`,
      { mapId, locX, locY }
    );
  }

  loadMapData() {
    return this.http.get<MapDto[]>(`${this.apiBaseUrl}/api/maps`);
  }

  loadCombatantHabitats(mapId: number) {
    return this.http.get<CombatantHabitatDto[]>(
      `${this.apiBaseUrl}/api/maps/${mapId}/combatant-habitats`
    );
  }
}
