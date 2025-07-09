import { Component, inject } from '@angular/core';
import { FinancialApiService } from '../../services/financial-api.service';

@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard {
  apiService = inject(FinancialApiService);

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.apiService.getFinancialData('AAPL').subscribe({
      next: (data) => {
        console.log('Financial Data:', data);
      },
      error: (error) => {
        console.error('Error fetching financial data:', error);
      },
    });
  }
}
