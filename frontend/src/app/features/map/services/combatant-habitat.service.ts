import { Injectable } from '@angular/core';
import { CombatantHabitatDto } from '../../../shared/dto/combatant-habitat.dto';

@Injectable({
  providedIn: 'root',
})
export class CombatantHabitatService {
  findHabitatAt(
    pos: [number, number],
    terrainTypeId: number,
    combatantHabitats: CombatantHabitatDto[]
  ): CombatantHabitatDto | null {
    const [posX, posY] = pos;

    const habitat = combatantHabitats.find(h =>
      Number(terrainTypeId) === Number(h.terrainTypeId) &&
      posX >= h.locX1 &&
      posX <= h.locX2 &&
      posY >= h.locY1 &&
      posY <= h.locY2
    );

    return habitat ?? null;
  }

  
}
