import { RequirementCheck, RequirementType } from '../dto/item.dto';

export const requirementChecks: Record<RequirementType, RequirementCheck> = {
  Level: (value, character) => character.level >= value,
  Strength: (value, character) => character.strength >= value,
  Dexterity: (value, character) => character.dexterity >= value,
  Intelligence: (value, character) => character.intelligence >= value,
  Race: (value, character) => character.characterRace.id === value,
  Class: (value, character) => character.characterClass.id === value,
};
