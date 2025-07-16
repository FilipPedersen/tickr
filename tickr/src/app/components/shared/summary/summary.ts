import { Component } from "@angular/core"
import { MatCardModule } from "@angular/material/card"

@Component({
    selector: "app-summary",
    imports: [MatCardModule],
    templateUrl: "./summary.html",
    styleUrl: "./summary.scss",
})
export class Summary {}
