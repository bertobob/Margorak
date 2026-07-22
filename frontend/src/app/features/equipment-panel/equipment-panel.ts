import { Component, inject } from '@angular/core';
import { EquipmentService } from './services/equipment-service';
import { EquipmentSlot } from './dto/equipment-panel.dto';
import { ItemDto } from '../../shared/dto/item.dto';
import { EquipmentStats } from './equipment-stats/equipment-stats';

@Component({
  selector: 'app-equipment-panel',
  imports: [EquipmentStats],
  templateUrl: './equipment-panel.html',
  styleUrl: './equipment-panel.css',
})
export class EquipmentPanel {
  private readonly equipmentService = inject(EquipmentService);

  protected readonly equipment = this.equipmentService.equipment;

  protected onItemClick(item: ItemDto): void {
    this.equipmentService.selectItem(item);
  }

  protected onUnequipClicked(slot: EquipmentSlot): void {
    this.equipmentService.onUnequipClicked(slot);
  }
}
