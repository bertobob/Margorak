export interface AggregatedEquipmentStats {
  attackRating: number;
  weight: number;
  armorValue: number;
  evasionValue: number;
  attackSpeed: number;
  attackRange: number;

  physicalMinDamage: number;
  physicalMaxDamage: number;
  fireMinDamage: number;
  fireMaxDamage: number;
  iceMinDamage: number;
  iceMaxDamage: number;
  lightMinDamage: number;
  lightMaxDamage: number;
  poisonMinDamage: number;
  poisonMaxDamage: number;
  lifeLeechMinDamage: number;
  lifeLeechMaxDamage: number;
  poisonDurationMinDamage: number;
  poisonDurationMaxDamage: number;

  physicalResistance: number;
  fireResistance: number;
  iceResistance: number;
  lightResistance: number;
  poisonResistance: number;
  strengthBonus: number;
  dexterityBonus: number;
  vitalityBonus: number;
  intelligenceBonus: number;
  evasionBonus: number;
}
