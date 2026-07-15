import { Component, inject, OnInit, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { forkJoin } from 'rxjs';
import { ApiService } from '../../core/services/api-service';
import { GameStateService } from '../../core/services/game-state.service';
import { CharacterClassDto, CharacterDto, CharacterRaceDto } from '../character/dto/character.dto';
import { CreateCharacterDto } from '../character/dto/create-character.dto';

@Component({
  selector: 'app-character-generation',
  imports: [ReactiveFormsModule],
  templateUrl: './character-generation.html',
  styleUrl: './character-generation.css',
})
export class CharacterGeneration implements OnInit {
  private readonly apiService = inject(ApiService);
  private readonly gameState = inject(GameStateService);

  public readonly races = signal<CharacterRaceDto[]>([]);
  public readonly classes = signal<CharacterClassDto[]>([]);
  public readonly loadingOptions = signal(true);
  public readonly creating = signal(false);
  public readonly errorMessage = signal('');

  public readonly form = new FormGroup({
    name: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.pattern(/\S/)],
    }),
    characterRaceId: new FormControl<number | null>(null, Validators.required),
    characterClassId: new FormControl<number | null>(null, Validators.required),
  });

  public ngOnInit(): void {
    this.loadCharacterOptions();
  }

  public createCharacter(): void {
    const request = this.buildCreateRequest();

    if (request === null) {
      return;
    }

    this.submitCharacter(request);
  }

  private loadCharacterOptions(): void {
    forkJoin({
      races: this.apiService.loadCharacterRaces(),
      classes: this.apiService.loadCharacterClasses(),
    }).subscribe({
      next: ({ races, classes }) => this.setCharacterOptions(races, classes),
      error: () => this.handleOptionsError(),
    });
  }

  private setCharacterOptions(races: CharacterRaceDto[], classes: CharacterClassDto[]): void {
    this.races.set(races);
    this.classes.set(classes);
    this.form.patchValue({
      characterRaceId: races[0]?.id ?? null,
      characterClassId: classes[0]?.id ?? null,
    });
    this.loadingOptions.set(false);
  }

  private handleOptionsError(): void {
    this.errorMessage.set('Races and classes could not be loaded.');
    this.loadingOptions.set(false);
  }

  private buildCreateRequest(): CreateCharacterDto | null {
    if (this.form.invalid || this.creating()) {
      this.form.markAllAsTouched();
      return null;
    }

    const { name, characterRaceId, characterClassId } = this.form.getRawValue();

    if (characterRaceId === null || characterClassId === null) {
      return null;
    }

    return {
      name: name.trim(),
      characterRaceId,
      characterClassId,
    };
  }

  private submitCharacter(request: CreateCharacterDto): void {
    this.creating.set(true);
    this.errorMessage.set('');

    this.apiService.createCharacter(request).subscribe({
      next: (character) => this.handleCharacterCreated(character),
      error: (error) => {
        console.error('Create character failed', {
          status: error.status,
          body: error.error,
          message: error.message,
        });

        this.handleCreateError();
      },
    });
  }

  private handleCharacterCreated(character: CharacterDto): void {
    this.gameState.addCharacter(character);
    this.gameState.setActiveCharacter(character);
    this.form.controls.name.reset('');
    this.creating.set(false);
  }

  private handleCreateError(): void {
    this.errorMessage.set('The character could not be created.');
    this.creating.set(false);
  }
}
