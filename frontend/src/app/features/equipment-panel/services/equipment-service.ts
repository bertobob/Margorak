import { computed, inject, Injectable, signal } from '@angular/core';
import { EquipmentSlot } from '../dto/equipment-panel.dto';
import { GameStateService } from '../../../core/services/game-state.service';
import { InventoryItemDto } from '../../../shared/dto/inventory-item.dto';
import { ItemDto } from '../../../shared/dto/item.dto';
import { createEmptyEquipmentStats } from '../equipment-stats/equipment-stats.factory';
import { AggregatedEquipmentStats } from '../equipment-stats/equipment-stats.model';

const damageFields = {
  Physical: ['physicalMinDamage', 'physicalMaxDamage'],
  Fire: ['fireMinDamage', 'fireMaxDamage'],
  Ice: ['iceMinDamage', 'iceMaxDamage'],
  Light: ['lightMinDamage', 'lightMaxDamage'],
  Poison: ['poisonMinDamage', 'poisonMaxDamage'],
  LifeLeech: ['lifeLeechMinDamage', 'lifeLeechMaxDamage'],
  PoisonDuration: ['poisonDurationMinDamage', 'poisonDurationMaxDamage'],
} as const;

const resistanceFields = {
  Physical: 'physicalResistance',
  Fire: 'fireResistance',
  Ice: 'iceResistance',
  Light: 'lightResistance',
  Poison: 'poisonResistance',
} as const;

const bonusFields = {
  Strength: 'strengthBonus',
  Dexterity: 'dexterityBonus',
  Vitality: 'vitalityBonus',
  Intelligence: 'intelligenceBonus',
  Evasion: 'evasionBonus',
} as const;

@Injectable({
  providedIn: 'root',
})
export class EquipmentService {
  gameStateService = inject(GameStateService);
  selectedItemStats = signal<ItemDto | null>(null);
  equipment = this.gameStateService.equipment;

  equipmentStats = computed<AggregatedEquipmentStats>(() => {
    const stats = createEmptyEquipmentStats();

    for (const inventoryItem of Object.values(this.equipment())) {
      if (!inventoryItem) {
        continue;
      }

      const item = inventoryItem.item;
      stats.attackRating += item.attackRating ?? 0;
      stats.weight += item.weight ?? 0;
      stats.attackSpeed += item.weaponStat?.attackSpeed ?? 0;
      stats.attackRange += item.weaponStat?.attackRange ?? 0;

      for (const damage of item.itemDamages) {
        const fields = damageFields[damage.damageType.name as keyof typeof damageFields];
        if (fields) {
          stats[fields[0]] += damage.minDamage ?? 0;
          stats[fields[1]] += damage.maxDamage ?? 0;
        }
      }

      for (const resistance of item.itemResistances) {
        if (resistance.resistanceType.name === 'Defense') {
          stats.armorValue += resistance.value ?? 0;
          continue;
        }

        if (resistance.resistanceType.name === 'Evasion') {
          stats.evasionValue += resistance.value ?? 0;
          continue;
        }

        const field =
          resistanceFields[resistance.resistanceType.name as keyof typeof resistanceFields];
        if (field) {
          stats[field] += resistance.value ?? 0;
        }
      }

      for (const bonus of item.itemBonuses) {
        const field = bonusFields[bonus.bonusType.name as keyof typeof bonusFields];
        if (field) {
          stats[field] += bonus.value ?? 0;
        }
      }
    }

    return stats;
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

  selectItem(item: ItemDto): void {
    this.selectedItemStats.set(item);
  }
}
