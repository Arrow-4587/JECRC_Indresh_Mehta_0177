import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, CommonModule],
  template: `
 <h1>routing-demo</h1>
 <nav>
   <a routerLink="/">Home</a> |
   <a routerLink="/contact">Contact</a> |
   <a routerLink="/products">Product</a>
 </nav>

 <hr>

 <router-outlet></router-outlet>
  `
})
export class App {
  protected readonly title = signal('routing-demo');
}
