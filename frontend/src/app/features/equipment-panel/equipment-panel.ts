import { Component, inject } from '@angular/core';
import { EquipmentService } from './services/equipment-service';

@Component({
  selector: 'app-equipment-panel',
  imports: [],
  templateUrl: './equipment-panel.html',
  styleUrl: './equipment-panel.css',
})
export class EquipmentPanel {
  private readonly equipmentService = inject(EquipmentService);

  protected readonly equipment = this.equipmentService.equipment;
}
