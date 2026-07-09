import { Component, signal } from '@angular/core';
import { Map } from './features/map/map';
import { Inventory } from './features/inventory/inventory';
import { InteractionBar } from './features/interaction-bar/interaction-bar';

@Component({
  selector: 'app-root',
  imports: [Map, Inventory, InteractionBar],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('margorak');
  protected activeView = signal<'map' | 'inventory'>('map');

  protected showMap(): void {
    this.activeView.set('map');
  }

  protected showInventory(): void {
    this.activeView.set('inventory');
  }
}
