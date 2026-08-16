import { Component, input } from '@angular/core';

@Component({
  selector: 'app-health-bar',
  imports: [],
  templateUrl: './health-bar.html',
  styleUrl: './health-bar.css',
})
export class HealthBar {
  currentHp = input.required<number>();
  maxHp = input.required<number>();
  protected hpPercent(currentHp: number, maxHp: number): number {
    if (maxHp <= 0) {
      return 0;
    }

    return Math.max(0, Math.min(100, (currentHp / maxHp) * 100));
  }
}
