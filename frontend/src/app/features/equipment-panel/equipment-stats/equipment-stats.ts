import { Component, inject } from '@angular/core';
import { EquipmentService } from '../services/equipment-service';

@Component({
  selector: 'app-equipment-stats',
  imports: [],
  templateUrl: './equipment-stats.html',
  styleUrl: './equipment-stats.css',
})
export class EquipmentStats {
  private readonly equipmentService = inject(EquipmentService);
  protected readonly stats = this.equipmentService.equipmentStats;
}
