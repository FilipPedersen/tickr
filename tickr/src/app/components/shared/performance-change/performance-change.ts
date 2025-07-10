import { Component, input } from '@angular/core';

@Component({
  selector: 'app-performance-change',
  imports: [],
  templateUrl: './performance-change.html',
  styleUrl: './performance-change.scss',
})
export class PerformanceChange {
  title = input<string>('');
  value = input<number>(0);
  change = input<number>(0);

  get changeClass(): string {
    return this.change() >= 0 ? 'text-green-500' : 'text-red-500';
  }
}
