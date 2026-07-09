interface BaseInteractionDto {
  id: number;
  type: string;
  description: string;
}

export interface ShopInteractionDto extends BaseInteractionDto {
  type: 'shop';
  shopName: string;
}

export interface TeleporterInteractionDto extends BaseInteractionDto {
  type: 'teleporter';
  destinationMapId: number;
  destinationLocX: number;
  destinationLocY: number;
}

export type MapInteractionDto = ShopInteractionDto | TeleporterInteractionDto;

export interface MapInteractionHandler {
  type: MapInteractionDto['type'];
  handle(interaction: MapInteractionDto): void;
}
