export interface ItemDto {
  id: number;
  name: string;
  itemCategory: ItemCategoryDto;
  itemDamages: ItemDamageDto[];
  itemRequirements: ItemRequirementDto[];
  itemResistances: ItemResistanceDto[];
  armorStat: ArmorStatDto | null;
  weaponStat: WeaponStatDto | null;
  consumableEffects: ConsumableEffectDto[];
  itemBonuses: ItemBonusDto[];
  description: string;
  value: number;
  weight: number;
  attackRating: number;
}

export interface ItemCategoryDto {
  id: number;
  name: string;
}

export interface ItemDamageDto {
  damageType: DamageTypeDto;
  minDamage: number;
  maxDamage: number;
}

export interface DamageTypeDto {
  name: string;
}

export interface ItemRequirementDto {
  requirementType: RequirementTypeDto;
  value: number;
}

export interface RequirementTypeDto {
  name: string;
}

export interface ItemResistanceDto {
  resistanceType: ResistanceTypeDto;
  value: number;
}

export interface ResistanceTypeDto {
  name: string;
}

export interface ArmorStatDto {
  armorValue: number;
  evasionValue: number;
  equipSlot: EquipSlotDto;
}

export interface EquipSlotDto {
  id: number;
  name: string;
}

export interface WeaponStatDto {
  attackSpeed: number;
  attackRange: number;
}

export interface ConsumableEffectDto {
  effectType: EffectTypeDto;
  minValue: number;
  maxValue: number;
  duration: number | null;
}

export interface EffectTypeDto {
  name: string;
}

export interface ItemBonusDto {
  bonusType: BonusTypeDto;
  value: number;
}

export interface BonusTypeDto {
  name: string;
}
