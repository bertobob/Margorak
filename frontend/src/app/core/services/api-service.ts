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
import {
  ShopDto,
  TradeItemRequestDto,
  TradeItemResponseDto,
} from '../../features/shop/dto/shop.dto';
import { ActiveCombatDto } from '../../features/combat/dto/combat.dto';
import { Observable } from 'rxjs';
import { LocationDto } from '../../features/character/dto/location.dto';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private readonly httpClient = inject(HttpClient);
  private apiBaseUrl = environment.apiBaseUrl;

  saveCharacter(characterId: number, saveCharacterDto: SaveCharacterDto) {
    return this.httpClient.put<void>(
      `${this.apiBaseUrl}/api/characters/${characterId}/save`,
      saveCharacterDto
    );
  }

  getCharacters() {
    return this.httpClient.get<CharacterDto[]>(`${this.apiBaseUrl}/api/characters`);
  }

  loadCharacter(characterId: number) {
    return this.httpClient.get<LoadCharacterDto>(`${this.apiBaseUrl}/api/characters/${characterId}/load`);
  }

  getCharacterRaces() {
    return this.httpClient.get<CharacterRaceDto[]>(`${this.apiBaseUrl}/api/characters/options/races`);
  }

  getCharacterClasses() {
    return this.httpClient.get<CharacterClassDto[]>(`${this.apiBaseUrl}/api/characters/options/classes`);
  }
  respawnCharacter(characterId: number) {
    return this.httpClient.put<LocationDto>(
      `${this.apiBaseUrl}/api/characters/${characterId}/respawnCharacter`,
      characterId
    );
  }
  createCharacter(character: CreateCharacterDto) {
    return this.httpClient.post<CharacterDto>(`${this.apiBaseUrl}/api/characters`, character);
  }

  getMapData() {
    return this.httpClient.get<MapDto[]>(`${this.apiBaseUrl}/api/maps`);
  }

  getCombatantHabitatsByMapId(mapId: number) {
    return this.httpClient.get<CombatantHabitatDto[]>(
      `${this.apiBaseUrl}/api/maps/${mapId}/combatant-habitats`
    );
  }
  getItemById(itemId: number) {
    return this.httpClient.get<ItemDto>(`${this.apiBaseUrl}/api/items/${itemId}`);
  }

  loadShop(shopInteractionId: number) {
    return this.httpClient.get<ShopDto>(`${this.apiBaseUrl}/api/shops/${shopInteractionId}`);
  }

  buy(item: TradeItemRequestDto, shopInteractionId: number) {
    return this.httpClient.post<TradeItemResponseDto>(
      `${this.apiBaseUrl}/api/shops/${shopInteractionId}/buy`,
      item
    );
  }

  sell(item: TradeItemRequestDto, shopInteractionId: number) {
    return this.httpClient.post<TradeItemResponseDto>(
      `${this.apiBaseUrl}/api/shops/${shopInteractionId}/sell`,
      item
    );
  }

  startCombat(characterId: number, combatantId: number): Observable<ActiveCombatDto> {
    return this.httpClient.get<ActiveCombatDto>(`${this.apiBaseUrl}/api/combat/startCombat`, {
      params: {
        characterId,
        combatantId,
      },
    });
  }

  endCombat(characterId: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiBaseUrl}/api/combat/stopCombat`, {
      params: {
        characterId,
      },
    });
  }

  attack(characterId: number): Observable<ActiveCombatDto> {
    return this.httpClient.post<ActiveCombatDto>(`${this.apiBaseUrl}/api/combat/attack`, null, {
      params: {
        characterId,
      },
    });
  }
}
