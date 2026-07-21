import { Component } from '@angular/core';
import { NavigationBar } from './features/navigation-bar/navigation-bar';
import { EquipmentPanel } from './features/equipment-panel/equipment-panel';

@Component({
  selector: 'app-root',
  imports: [NavigationBar, EquipmentPanel],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {}
