import { Component } from '@angular/core';
import { PerformanceChange } from '../performance-change/performance-change';

@Component({
  selector: 'app-top-nav',
  imports: [PerformanceChange],
  templateUrl: './top-nav.html',
  styleUrl: './top-nav.scss',
})
export class TopNav {
  title = 'Tickr Dashboard';

  constructor() {
    // Initialization logic can go here if needed
  }
}
