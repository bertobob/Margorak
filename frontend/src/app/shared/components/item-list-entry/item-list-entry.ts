import { Component, inject, input } from '@angular/core';
import { EquipmentService } from '../../../core/services/equipment.service';
import { ItemDto } from '../../dto/item.dto';

@Component({
  selector: 'li[app-item-list-entry]',
  imports: [],
  templateUrl: './item-list-entry.html',
  styleUrl: './item-list-entry.css',
})
export class ItemListEntry {
  private readonly equipmentService = inject(EquipmentService);

  readonly item = input.required<ItemDto>();
  readonly quantity = input<number | null>(null);

  protected readonly selectedItemStats = this.equipmentService.selectedItemStats;

  protected selectItem(): void {
    this.equipmentService.selectItem(this.item());
  }
}
