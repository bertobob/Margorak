export interface CharacterDto {
  id: number;
  name: string;
  gender: string;

  characterRace: CharacterRaceDto;
  characterClass: CharacterClassDto;

  level: number;
  experience: number;
  statusPoints: number;

  strength: number;
  dexterity: number;
  vitality: number;
  intelligence: number;

  currentHp: number;
  maxHp: number;
  currentMp: number;
  maxMp: number;

  gold: number;

  currentMapId: number;
  locX: number;
  locY: number;

  version: number;
}
export interface CharacterRaceDto {
  id: number;
  name: string;
  strengthMod: number;
  dexterityMod: number;
  vitalityMod: number;
  intelligenceMod: number;
}

export interface CharacterClassDto {
  id: number;
  name: string;
}
