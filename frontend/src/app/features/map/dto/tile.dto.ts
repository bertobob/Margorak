import { MapInteractionDto } from './map-interaction.dto';

export interface TileDto {
  terrainId: number;
  terrainTypeId: number;
  accessible: number;
  mapInteraction?: MapInteractionDto | null;
}
