import { TileDto } from './tile.dto';

export interface MapDto {
  id: number;
  name: string;
  sightRange: number;
  clickRange: number;
  tiles: TileDto[][];
}
