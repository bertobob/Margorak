import { inject, Injectable, signal } from '@angular/core';
import { Equipment, EquipmentSlot } from '../dto/equipment-panel.dto';
import { GameStateService } from '../../../core/services/game-state.service';
import { InventoryItemDto } from '../../../shared/dto/inventory-item.dto';

@Injectable({
  providedIn: 'root',
})
export class EquipmentService {
  gameStateService = inject(GameStateService);
  equipment = signal<Equipment>({
    Helmet: null,
    Chest: null,
    Legs: null,
    Gloves: null,
    Boots: null,
    Weapon: null,
    Shield: null,
    Ring: null,
    Amulet: null,
  });

  onEquipClicked(inventoryItem: InventoryItemDto): void {
    const slot = inventoryItem.item.itemCategory.equipSlot?.name as EquipmentSlot;
    this.equipment.update((equipment) => ({ ...equipment, [slot]: inventoryItem }));
    this.gameStateService.removeInventoryItem(inventoryItem.ownedItemId);
  }

  onUnequipClicked(slot: EquipmentSlot): void {
    const inventoryItem = this.equipment()[slot];

    if (!inventoryItem) {
      return;
    }

    this.gameStateService.addInventoryItem(inventoryItem);
    this.equipment.update((equipment) => ({ ...equipment, [slot]: null }));
  }
}
