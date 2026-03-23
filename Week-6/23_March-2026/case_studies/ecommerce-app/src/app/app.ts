import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProductList } from './components/product-list/product-list';
import { Cart } from './components/cart/cart';
import { Checkout } from './components/checkout/checkout';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, ProductList, RouterOutlet, Cart, Checkout],
  styleUrl: './app.css',
  template: `
    <h1>{{ title() }}</h1>
   <div class="container">
      <app-product-list></app-product-list>
      <app-cart></app-cart>
      <app-checkout></app-checkout>
    </div>
  `
})
export class App {
  protected readonly title = signal('ecommerce-app');
}
