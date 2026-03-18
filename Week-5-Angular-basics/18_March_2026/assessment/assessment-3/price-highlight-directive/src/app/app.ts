import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PriceHighlightDirective } from './directives/price-highlight';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, PriceHighlightDirective],
  templateUrl: './app.html',
})
export class App {}