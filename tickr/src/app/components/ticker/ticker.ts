import { Component, inject, signal } from "@angular/core"
import {
    ChartData,
    FinancialApiService,
} from "../../services/financial-api.service"
import { of } from "rxjs"
import { Overview } from "./overview/overview"
import { MatTabsModule } from "@angular/material/tabs"
import { Summary } from "../shared/summary/summary"

@Component({
    selector: "app-ticker",
    imports: [Overview, MatTabsModule, Summary],
    templateUrl: "./ticker.html",
    styleUrl: "./ticker.scss",
})
export class Ticker {
    apiService = inject(FinancialApiService)
    chartData = signal<ChartData | null>(null)

    ngOnInit() {
        this.loadData()
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
            console.log("Financial Data:", data)
            this.chartData.set(data)
        })
    }
}

const testdata: ChartData = {
    symbol: "AAPL",
    yearly: {
        metrics: [
            {
                name: "Revenue",
                chartView: {
                    labels: ["2024", "2023", "2022", "2021", "2020"],
                    data: [
                        391035000000, 383285000000, 394328000000, 365817000000,
                        274515000000,
                    ],
                },
            },
            {
                name: "NetIncome",
                chartView: {
                    labels: ["2024", "2023", "2022", "2021", "2020"],
                    data: [
                        93736000000, 96995000000, 99803000000, 94680000000,
                        57411000000,
                    ],
                },
            },
            {
                name: "OperatingExpenses",
                chartView: {
                    labels: ["2024", "2023", "2022", "2021", "2020"],
                    data: [
                        57467000000, 54847000000, 51345000000, 43887000000,
                        38668000000,
                    ],
                },
            },
            {
                name: "GrossProfit",
                chartView: {
                    labels: ["2024", "2023", "2022", "2021", "2020"],
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
                name: "Revenue",
                chartView: {
                    labels: [],
                    data: [],
                },
            },
            {
                name: "NetIncome",
                chartView: {
                    labels: [],
                    data: [],
                },
            },
            {
                name: "OperatingExpenses",
                chartView: {
                    labels: [],
                    data: [],
                },
            },
            {
                name: "GrossProfit",
                chartView: {
                    labels: [],
                    data: [],
                },
            },
        ],
    },
}
