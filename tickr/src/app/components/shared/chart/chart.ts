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
                const ctx = (
                    document.querySelector("canvas") as HTMLCanvasElement
                )?.getContext("2d")
                if (ctx) {
                    const gradient = ctx.createLinearGradient(
                        0,
                        0,
                        0,
                        ctx.canvas.height
                    )
                    gradient.addColorStop(
                        0,
                        this.color()?.color || "rgba(0,0,0,0)"
                    )
                    gradient.addColorStop(1, "rgba(255,255,255,0)")

                    this.chartConfig().data.datasets = [
                        {
                            label: this.formatLabel(data.name),
                            data: data.chartView.data.reverse(),
                            backgroundColor: gradient,
                            borderColor: this.color()?.border,
                            borderWidth: 1,
                        },
                    ]
                }
            }
        })
    }

    formatLabel(label: string): string {
        if (!label) return ""
        return label
            .replace(/([A-Z])/g, " $1")
            .replace(/^./, (str) => str.toUpperCase())
            .trim()
    }
}
