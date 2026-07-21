import { ItemDto } from '../../../shared/dto/item.dto';

export type EquipmentSlot =
  'Helmet' | 'Chest' | 'Legs' | 'Gloves' | 'Boots' | 'Weapon' | 'Shield' | 'Ring' | 'Amulet';

export type Equipment = Record<EquipmentSlot, ItemDto | null>;
