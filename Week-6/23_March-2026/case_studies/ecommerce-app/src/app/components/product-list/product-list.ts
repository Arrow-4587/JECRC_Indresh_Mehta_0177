import { Component, OnInit } from '@angular/core';
// import { Product } from '../product';
import { ProductService } from '../../product.service';
import { CartService } from '../../cart.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-list',
  imports: [CommonModule],
  templateUrl: './product-list.html',
  styleUrl: './product-list.css',
})
export class ProductList implements OnInit {
  products: any[] = [];

  constructor(
    private productService: ProductService,
    private cartService: CartService
  ) {}

  ngOnInit(): void {
    this.products = this.productService.getProducts();
  }

  addToCart(product: any): void {
    this.cartService.addToCart(product);
    alert(`${product.name} added to cart!`);
  }
}
