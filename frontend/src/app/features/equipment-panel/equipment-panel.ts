import { Component, computed, inject } from '@angular/core';
import { EquipmentService } from '../../core/services/equipment.service';
import { EquipmentSlot } from './dto/equipment-panel.dto';
import { ItemDto } from '../../shared/dto/item.dto';
import { EquipmentStats } from './equipment-stats/equipment-stats';
import { GameStateService } from '../../core/services/game-state.service';

@Component({
  selector: 'app-equipment-panel',
  imports: [EquipmentStats],
  templateUrl: './equipment-panel.html',
  styleUrl: './equipment-panel.css',
})
export class EquipmentPanel {
  private readonly equipmentService = inject(EquipmentService);
  private readonly gamestate = inject(GameStateService);

  protected readonly equipment = this.equipmentService.equipment;
  protected readonly combatActive = computed(() => {
    return this.gamestate.activeCombat() !== null;
  });

  protected onItemClick(item: ItemDto): void {
    this.equipmentService.selectItem(item);
  }

  protected onUnequipClicked(slot: EquipmentSlot): void {
    this.equipmentService.onUnequipClicked(slot);
  }
}
