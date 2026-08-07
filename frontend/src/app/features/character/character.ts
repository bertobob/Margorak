import { Component, effect, inject, signal } from '@angular/core';
import { GameStateService } from '../../core/services/game-state.service';
import { CharacterDto, CharacterStat } from './dto/character.dto';

@Component({
  selector: 'app-character',
  imports: [],
  templateUrl: './character.html',
  styleUrl: './character.css',
})
export class Character {
  private readonly gameState = inject(GameStateService);
  character = this.gameState.activeCharacter;
  editedCharacter = signal<CharacterDto | null>(null);
  characterEdited = signal(false);

  constructor() {
    effect(() => {
      const character = this.character();
      this.editedCharacter.set(character ? { ...character } : null);
    });
  }

  hasAvailableStatPoints(): boolean {
    return (this.editedCharacter()?.statusPoints ?? 0) > 0;
  }

  increaseStat(stat: CharacterStat): void {
    const editedCharacter = this.editedCharacter();

    if (!editedCharacter) {
      return;
    }

    editedCharacter[stat]++;
    editedCharacter.statusPoints--;
    this.characterEdited.set(true);
  }

  saveChanges(): void {
    const editedCharacter = this.editedCharacter();
    this.character.set(editedCharacter ? { ...editedCharacter } : null);
    this.characterEdited.set(false);
  }

  resetChanges(): void {
    const character = this.character();
    this.editedCharacter.set(character ? { ...character } : null);
    this.characterEdited.set(false);
  }
}
