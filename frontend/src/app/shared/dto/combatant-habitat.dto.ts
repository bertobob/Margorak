export interface CombatantHabitatDto {
  combatantId: number;
  terrainTypeId: number;
  locX1: number;
  locY1: number;
  locX2: number;
  locY2: number;
  probability: number;
  ambushProbability: number;
}

export interface HabitatTerrainTypeDto {
  id: number;
  name: string;
}
