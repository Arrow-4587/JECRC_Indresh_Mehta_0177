import { Component } from '@angular/core';
import { ThemeDirective } from './directives/theme';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ThemeDirective],
  templateUrl: './app.html',
})
export class App {
  theme: 'light' | 'dark' = 'light';

  toggleTheme() {
    this.theme = this.theme === 'light' ? 'dark' : 'light';
  }
}