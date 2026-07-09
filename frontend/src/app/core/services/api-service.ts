import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../config/config';
import { MapDto } from '../../features/map/dto/map.dto';
import { CombatantHabitatDto } from '../../shared/dto/combatant-habitat.dto';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private http = inject(HttpClient);
  private apiBaseUrl = environment.apiBaseUrl;

  saveUser(clientId: string) {
    //return this.http.post<void>(`${this.apiBaseUrl}/api/client-data/user`,{clientId})
  }

  loadMapData() {
    return this.http.get<MapDto[]>(`${this.apiBaseUrl}/api/map/maps`);
  }

  loadCombatantHabitats(mapId: number) {
    return this.http.get<CombatantHabitatDto[]>(`${this.apiBaseUrl}/combatantHabitats/${mapId}`);
  }
}
