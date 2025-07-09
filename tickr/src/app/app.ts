import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FinancialApiService } from './services/financial-api.service';
import { TopNav } from './components/shared/top-nav/top-nav';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TopNav],
  providers: [FinancialApiService],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  protected title = 'tickr';
}
