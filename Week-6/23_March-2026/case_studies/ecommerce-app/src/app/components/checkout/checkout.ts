import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  imports: [CommonModule, FormsModule],
  templateUrl: './checkout.html',
  styleUrl: './checkout.css',
})
export class Checkout {
  form = {
    name: '',
    address: '',
    email: '',
    payment: ''
  };
  submit()
  {
    alert(`Order placed for ${this.form.name} with email ${this.form.email}`);
    console.log('Order details:', this.form);
  }
}
