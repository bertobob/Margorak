interface BaseInteractionDto {
  id: number;
}

export interface ShopInteractionDto extends BaseInteractionDto {
  type: 'shop';
  shopName: string;
}

export interface TeleporterInteractionDto extends BaseInteractionDto {
  type: 'teleporter';
  targetMapId: number;
  targetX: number;
  targetY: number;
}

export type MapInteractionDto =
  | ShopInteractionDto
  | TeleporterInteractionDto;
