import { Component, inject, signal } from '@angular/core';
import { GameStateService } from '../../core/services/game-state.service';
import { ItemDto, ItemRequirementDto } from '../../shared/dto/item.dto';
import { allRequirementsMet, requirementChecks } from '../../shared/utils/requirement-checks';
import { EquipmentService } from '../equipment-panel/services/equipment-service';
import { InventoryItemDto } from '../../shared/dto/inventory-item.dto';

@Component({
  selector: 'app-inventory',
  imports: [],
  templateUrl: './inventory.html',
  styleUrl: './inventory.css',
})
export class Inventory {
  private gameState = inject(GameStateService);
  private equipmentService = inject(EquipmentService);
  protected selectedItemStats = signal<ItemDto | null>(null);
  protected inventory = this.gameState.currentInventory;

  protected onItemClick(item: ItemDto): void {
    this.selectedItemStats.set(item);
  }

  protected onEquipClicked(inventoryItem: InventoryItemDto): void {
    this.equipmentService.onEquipClicked(inventoryItem);
  }

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

  protected isAllRequirementsMet(itemRequirements: ItemRequirementDto[]): boolean {
    const character = this.gameState.activeCharacter();

    if (!character) {
      return false;
    }
    return allRequirementsMet(itemRequirements, character);
  }
}
