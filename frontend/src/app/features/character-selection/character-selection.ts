import { Component, inject } from '@angular/core';
import { GameStateService } from '../../core/services/game-state.service';
import { CharacterDto } from '../character/dto/character.dto';
import { CharacterGeneration } from '../character-generation/character-generation';

@Component({
  selector: 'app-character-selection',
  imports: [CharacterGeneration],
  templateUrl: './character-selection.html',
  styleUrl: './character-selection.css',
})
export class CharacterSelection {
  private readonly gameState = inject(GameStateService);

  public readonly characters = this.gameState.characters.asReadonly();
  public readonly activeCharacter = this.gameState.activeCharacter.asReadonly();

  public selectCharacter(character: CharacterDto): void {
    this.gameState.setActiveCharacter(character);
  }
}
