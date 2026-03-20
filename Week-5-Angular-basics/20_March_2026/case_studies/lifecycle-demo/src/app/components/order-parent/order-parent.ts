import { Component, DestroyRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderChild } from '../order-child/order-child';

@Component({
  selector: 'app-order-parent',
  standalone: true,
  imports: [CommonModule, OrderChild],
  templateUrl: './order-parent.html',
  styleUrls: ['./order-parent.css']
})
export class OrderParent {

  order = {
    id: 101,
    ProductName: 'Laptop',
    status: 'Pending',
    Price: 50000,
  };

  updateOrder() {
  this.order = {
    ...this.order,
    status: this.order.status === 'Pending' ? 'Delivered' : 'Pending'
  };
  }
  destroyChild = true;

  toggleChild() {
    this.destroyChild = !this.destroyChild;
  }
}