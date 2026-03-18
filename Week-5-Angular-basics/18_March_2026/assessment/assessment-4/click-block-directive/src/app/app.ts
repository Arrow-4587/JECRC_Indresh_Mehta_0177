import { Component } from '@angular/core';
import { ClickBlockDirective } from './directives/click-block';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, ClickBlockDirective],
  templateUrl: './app.html',
})
export class App {
  isAllowed = false;
}