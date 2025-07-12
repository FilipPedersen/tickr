import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FinancialApiService {
  private apiUrl = 'http://localhost:5236/api/financial';
  constructor(private http: HttpClient) {}

  getChartData(symbol: string): Observable<ChartData> {
    return this.http.get<ChartData>(`${this.apiUrl}/${symbol}`);
  }
}

export interface ChartData {
  symbol: string;
  yearly: MetricChartView;
  quarterly: MetricChartView;
}

export interface MetricChartView {
  metrics: Metric[];
}

export interface Metric {
  name: string;
  chartView: ChartView;
}

export interface ChartView {
  labels: string[];
  data: number[];
}
