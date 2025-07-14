import { Component, effect, input, signal } from "@angular/core"
import { Metric } from "../../../services/financial-api.service"
import { MatCardModule } from "@angular/material/card"
import { BaseChartDirective } from "ng2-charts"
import { ChartConfiguration, Legend } from "chart.js"
import { ChartColor, chartColors } from "../../../helpers/chart-config-helper"

@Component({
    selector: "app-chart",
    imports: [MatCardModule, BaseChartDirective],
    templateUrl: "./chart.html",
    styleUrl: "./chart.scss",
})
export class Chart {
    chartData = input<Metric | null>(null)
    viewType = input<"yearly" | "quarterly">("yearly")
    color = input<ChartColor | undefined>(undefined)

    chartConfig = signal<ChartConfiguration>({
        type: "bar",
        data: {
            labels: [],
            datasets: [],
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                x: {
                    ticks: {
                        autoSkip: false,
                    },
                    title: {
                        display: false,
                        text: "Year",
                    },
                },
                y: {
                    title: {
                        display: false,
                        text: "Value",
                    },
                },
            },
            plugins: {
                legend: {
                    display: false,
                },
                title: {
                    display: false,
                },
            },
        },
    })

    constructor() {
        effect(() => {
            const data = this.chartData()
            if (data) {
                this.chartConfig().data.labels = data.chartView.labels.reverse()
                this.chartConfig().data.datasets = [
                    {
                        label: data.name,
                        data: data.chartView.data.reverse(),
                        backgroundColor: this.color()?.color,
                        borderColor: this.color()?.border,
                        borderWidth: 1,
                    },
                ]
            }
        })
    }
}
