import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../product.service';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-detail',
  imports: [CommonModule],
  template: `
    <h2>Product Detail</h2>
    <div class = "card" *ngIf="product">
      <h3>{{ product.name }}</h3>
      <p>ID: {{ product.productID }}</p>
      <p>Price: {{ product.price }}</p>
    </div>
  `
})
export class ProductDetail implements OnInit {
  product: any;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService
  ) { }

  ngOnInit() {
     const id = Number(this.route.snapshot.paramMap.get('id'));
     this.product = this.productService.getProductById(id);
  }

}
