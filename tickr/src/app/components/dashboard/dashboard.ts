import { Component, inject, signal, Signal } from "@angular/core"
import {
    ChartData,
    FinancialApiService,
} from "../../services/financial-api.service"
import { of } from "rxjs"
import { MatInputModule } from "@angular/material/input"
import { MatFormFieldModule } from "@angular/material/form-field"
import { MatCardModule } from "@angular/material/card"
import { FormsModule } from "@angular/forms"
import { RouterLink } from "@angular/router"

@Component({
    selector: "app-dashboard",
    imports: [
        FormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatCardModule,
        RouterLink,
    ],
    templateUrl: "./dashboard.html",
    styleUrl: "./dashboard.scss",
})
export class Dashboard {
    recentSearches = signal<string[]>(["AAPL", "GOOGL", "MSFT", "AMZN", "TSLA"])
}
