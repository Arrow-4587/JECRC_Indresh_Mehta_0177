import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { OrderParent } from './components/order-parent/order-parent';

@Component({
  selector: 'app-root',
  imports: [OrderParent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('lifecycle-demo');
}
