import { Component, effect, inject, signal } from '@angular/core';
import { GameStateService } from '../../core/services/game-state.service';
import { CharacterDto, CharacterStat } from './dto/character.dto';
import { HealthBar } from '../../shared/components/health-bar/health-bar';
import { switchMap } from 'rxjs';
import { ApiService } from '../../core/services/api-service';

@Component({
  selector: 'app-character',
  imports: [HealthBar],
  templateUrl: './character.html',
  styleUrl: './character.css',
})
export class Character {
  private readonly gameStateService = inject(GameStateService);
  private readonly apiService = inject(ApiService);
  character = this.gameStateService.activeCharacter;
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

    this.gameStateService
      .saveCharacter()
      ?.pipe(
        switchMap(() => {
          this.characterEdited.set(false);

          return this.apiService.loadCharacter(editedCharacter!.id);
        })
      )
      .subscribe({
        next: (loadedCharacter) => {
          this.gameStateService.setLoadedCharacter(loadedCharacter);
        },
      });
  }

  resetChanges(): void {
    const character = this.character();
    this.editedCharacter.set(character ? { ...character } : null);
    this.characterEdited.set(false);
  }
}
