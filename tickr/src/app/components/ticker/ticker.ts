import { Component, inject, signal } from '@angular/core';
import {
  ChartData,
  ChartView,
  FinancialApiService,
  Metric,
  MetricChartView,
} from '../../services/financial-api.service';
import { of } from 'rxjs';
import { Chart } from '../shared/chart/chart';

@Component({
  selector: 'app-ticker',
  imports: [Chart],
  templateUrl: './ticker.html',
  styleUrl: './ticker.scss',
})
export class Ticker {
  apiService = inject(FinancialApiService);
  chartData = signal<ChartData | null>(null);
  viewType: 'yearly' | 'quarterly' = 'yearly';

  ngOnInit() {
    this.loadData();
  }
  loadData() {
    // this.apiService.getChartData('AAPL').subscribe({
    //   next: (data) => {
    //     console.log('Financial Data:', data);
    //   },
    //   error: (error) => {
    //     console.error('Error fetching financial data:', error);
    //   },
    // });
    of(testdata).subscribe((data) => {
      console.log('Financial Data:', data);
      this.chartData.set(data);
    });
  }

  getChartData(): Metric[] | null {
    if (!this.chartData()) {
      return null;
    }
    return this.viewType === 'yearly'
      ? (this.chartData()?.yearly.metrics ?? null)
      : (this.chartData()?.quarterly.metrics ?? null);
  }
}

const testdata: ChartData = {
  symbol: 'AAPL',
  yearly: {
    metrics: [
      {
        name: 'Revenue',
        chartView: {
          labels: ['2024', '2023', '2022', '2021', '2020'],
          data: [
            391035000000, 383285000000, 394328000000, 365817000000,
            274515000000,
          ],
        },
      },
      {
        name: 'NetIncome',
        chartView: {
          labels: ['2024', '2023', '2022', '2021', '2020'],
          data: [
            93736000000, 96995000000, 99803000000, 94680000000, 57411000000,
          ],
        },
      },
      {
        name: 'OperatingExpenses',
        chartView: {
          labels: ['2024', '2023', '2022', '2021', '2020'],
          data: [
            57467000000, 54847000000, 51345000000, 43887000000, 38668000000,
          ],
        },
      },
      {
        name: 'GrossProfit',
        chartView: {
          labels: ['2024', '2023', '2022', '2021', '2020'],
          data: [
            180683000000, 169148000000, 170782000000, 152836000000,
            104956000000,
          ],
        },
      },
    ],
  },
  quarterly: {
    metrics: [
      {
        name: 'Revenue',
        chartView: {
          labels: [],
          data: [],
        },
      },
      {
        name: 'NetIncome',
        chartView: {
          labels: [],
          data: [],
        },
      },
      {
        name: 'OperatingExpenses',
        chartView: {
          labels: [],
          data: [],
        },
      },
      {
        name: 'GrossProfit',
        chartView: {
          labels: [],
          data: [],
        },
      },
    ],
  },
};
