import { Component, input } from "@angular/core"
import { ChartData, Metric } from "../../../services/financial-api.service"
import { Chart } from "../../shared/chart/chart"
import { chartColors } from "../../../helpers/chart-config-helper"

@Component({
    selector: "app-overview",
    imports: [Chart],
    templateUrl: "./overview.html",
    styleUrl: "./overview.scss",
})
export class Overview {
    chartData = input<ChartData | null>(null)
    viewType: "yearly" | "quarterly" = "yearly"
    chartColors = chartColors

    getChartData(): Metric[] | null {
        if (!this.chartData()) {
            return null
        }
        return this.viewType === "yearly"
            ? (this.chartData()?.yearly.metrics ?? null)
            : (this.chartData()?.quarterly.metrics ?? null)
    }
}
