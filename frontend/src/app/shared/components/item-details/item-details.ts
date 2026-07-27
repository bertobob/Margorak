import { Component, inject } from '@angular/core';
import { EquipmentService } from '../../../core/services/equipment.service';
import { ItemRequirementDto } from '../../dto/item.dto';
import { GameStateService } from '../../../core/services/game-state.service';
import { requirementChecks } from '../../utils/requirement-checks';

@Component({
  selector: 'app-item-details',
  imports: [],
  templateUrl: './item-details.html',
  styleUrl: './item-details.css',
})
export class ItemDetails {
  private readonly equipmentService = inject(EquipmentService);
  private readonly gameState = inject(GameStateService);

  protected selectedItemStats = this.equipmentService.selectedItemStats;

  protected hasValue(value: number | null | undefined): value is number {
    return value !== null && value !== undefined && value !== 0;
  }

  protected isRequirementMet(requirement: ItemRequirementDto): boolean {
    const character = this.gameState.activeCharacter();

    if (!character) {
      return false;
    }

    const check = requirementChecks[requirement.requirementType.name];

    return check(requirement.value, character);
  }
}
