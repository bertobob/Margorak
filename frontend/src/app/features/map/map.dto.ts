export interface TileDto {
  terrainId: number
  accessible :number
  interaction?: MapInteraction;
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
  locX: number
  locY: number
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

