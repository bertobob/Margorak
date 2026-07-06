export interface TileDto {
  terrainId: number
  terrainTypeId : number
  accessible :number
  mapInteraction?: MapInteraction | null;
}

export interface MapDto {
  id: number;
  name: string;
  sightRange: number;
  clickRange: number;
  tiles: TileDto[][];
}

interface BaseInteraction {
  id: number
}

export interface ShopInteraction extends BaseInteraction {
  type: 'shop'
  shopName: string
}

export interface TeleporterInteraction extends BaseInteraction {
  type: 'teleporter'
  targetMapId: number
  targetX: number
  targetY: number
}

export type MapInteraction =
  | ShopInteraction
  | TeleporterInteraction

