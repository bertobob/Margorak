import { Component, inject, signal } from '@angular/core';
import { finalize, switchMap } from 'rxjs';
import { GameStateService } from '../../core/services/game-state.service';
import { ApiService } from '../../core/services/api-service';
import { CharacterDto } from '../character/dto/character.dto';
import { CharacterGeneration } from '../character-generation/character-generation';
import { PlayerMovementService } from '../map/services/player-movement.service';

@Component({
  selector: 'app-character-selection',
  imports: [CharacterGeneration],
  templateUrl: './character-selection.html',
  styleUrl: './character-selection.css',
})
export class CharacterSelection {
  private readonly gameState = inject(GameStateService);
  private readonly apiService = inject(ApiService);
  private readonly playerMovement = inject(PlayerMovementService);

  public readonly characters = this.gameState.characters.asReadonly();
  public readonly activeCharacter = this.gameState.activeCharacter.asReadonly();
  public readonly switchingCharacter = signal(false);

  public selectCharacter(character: CharacterDto): void {
    if (this.switchingCharacter() || this.activeCharacter()?.id === character.id) {
      return;
    }

    this.switchingCharacter.set(true);
    this.gameState.clearErrorMessage();

    const saveRequest = this.playerMovement.savePosition();
    const loadCharacterRequest = saveRequest
      ? saveRequest.pipe(switchMap(() => this.apiService.getCharacterById(character.id)))
      : this.apiService.getCharacterById(character.id);

    loadCharacterRequest.pipe(finalize(() => this.switchingCharacter.set(false))).subscribe({
      next: (freshCharacter) => this.gameState.setActiveCharacter(freshCharacter),
      error: (error) => {
        console.error('Character could not be switched.', error);
        this.gameState.setErrorMessage(
          'The current position could not be saved or the character could not be loaded.'
        );
      },
    });
  }
}
