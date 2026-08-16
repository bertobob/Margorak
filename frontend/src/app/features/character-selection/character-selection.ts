import { Component, inject, signal } from '@angular/core';
import { finalize, switchMap } from 'rxjs';
import { GameStateService } from '../../core/services/game-state.service';
import { ApiService } from '../../core/services/api-service';
import { CharacterDto } from '../character/dto/character.dto';
import { CharacterGeneration } from '../character-generation/character-generation';

@Component({
  selector: 'app-character-selection',
  imports: [CharacterGeneration],
  templateUrl: './character-selection.html',
  styleUrl: './character-selection.css',
})
export class CharacterSelection {
  private readonly gameStateService = inject(GameStateService);
  private readonly apiService = inject(ApiService);

  public readonly characters = this.gameStateService.characters.asReadonly();
  public readonly activeCharacter = this.gameStateService.activeCharacter.asReadonly();
  public readonly switchingCharacter = signal(false);

  public selectCharacter(character: CharacterDto): void {
    if (this.switchingCharacter() || this.activeCharacter()?.id === character.id) {
      return;
    }

    this.switchingCharacter.set(true);
    this.gameStateService.clearErrorMessage();
    this.gameStateService.activeEncounter.set(null);

    const saveRequest = this.gameStateService.saveCharacter();
    const loadCharacter = () => this.apiService.loadCharacter(character.id);
    const loadCharacterRequest = saveRequest
      ? saveRequest.pipe(switchMap(loadCharacter))
      : loadCharacter();

    loadCharacterRequest.pipe(finalize(() => this.switchingCharacter.set(false))).subscribe({
      next: (loadedCharacter) => {
        this.gameStateService.setLoadedCharacter(loadedCharacter);
        this.gameStateService.loadCombatantHabitats();
      },
      error: (error) => {
        console.error('Character could not be switched.', error);
        this.gameStateService.setErrorMessage(
          'The current position could not be saved or the character could not be loaded.'
        );
      },
    });
  }
}
