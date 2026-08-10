import { Injectable } from '@angular/core';
import { CombatantHabitatDto } from '../../../shared/dto/combatant-habitat.dto';

@Injectable({
  providedIn: 'root',
})
export class CombatantHabitatService {
  checkForEncounter(
    pos: [number, number],
    terrainTypeId: number,
    combatantHabitats: CombatantHabitatDto[]
  ): CombatantHabitatDto | null {
    const [posX, posY] = pos;
    const habitats = combatantHabitats
      .filter(
        (h) =>
          Number(terrainTypeId) === Number(h.terrainTypeId) &&
          posX >= h.locX1 &&
          posX <= h.locX2 &&
          posY >= h.locY1 &&
          posY <= h.locY2
      )
      .sort((habitatA, habitatB) => habitatA.probability - habitatB.probability);

    const probability = Math.random() * 100;
    const habitat = habitats.find((habitat) => habitat.probability >= probability);

    return habitat ?? null;
  }
}
