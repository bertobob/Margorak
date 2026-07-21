import { Injectable, signal } from '@angular/core';
import { Equipment } from '../dto/equipment-panel.dto';

@Injectable({
  providedIn: 'root',
})
export class EquipmentService {
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
}
