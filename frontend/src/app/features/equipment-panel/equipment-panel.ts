import { Component, inject } from '@angular/core';
import { EquipmentService } from './services/equipment-service';
import { EquipmentSlot } from './dto/equipment-panel.dto';

@Component({
  selector: 'app-equipment-panel',
  imports: [],
  templateUrl: './equipment-panel.html',
  styleUrl: './equipment-panel.css',
})
export class EquipmentPanel {
  private readonly equipmentService = inject(EquipmentService);

  protected readonly equipment = this.equipmentService.equipment;

  protected onUnequipClicked(slot: EquipmentSlot): void {
    this.equipmentService.onUnequipClicked(slot);
  }
}
