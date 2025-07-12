import { Component, input, signal } from '@angular/core';
import { Metric } from '../../../services/financial-api.service';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-chart',
  imports: [MatCardModule],
  templateUrl: './chart.html',
  styleUrl: './chart.scss',
})
export class Chart {
  chartData = input<Metric | null>(null);
  viewType = input<'yearly' | 'quarterly'>('yearly');
}
