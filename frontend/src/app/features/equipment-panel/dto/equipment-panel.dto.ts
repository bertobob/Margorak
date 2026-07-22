import { InventoryItemDto } from '../../../shared/dto/inventory-item.dto';

export type EquipmentSlot =
  'Helmet' | 'Chest' | 'Legs' | 'Gloves' | 'Boots' | 'Weapon' | 'Shield' | 'Ring' | 'Amulet';

export type Equipment = Record<EquipmentSlot, InventoryItemDto | null>;
