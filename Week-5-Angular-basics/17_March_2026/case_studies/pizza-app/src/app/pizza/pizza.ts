import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-pizza',
  imports: [FormsModule],
  templateUrl: './pizza.html',
  styleUrl: './pizza.css',
})
export class Pizza {
 pizzaName: string = '';
 quantity: number = 1;
 address: string = '';

 placeOrder() {
   console.log('Order placed:');
   console.log('Pizza:', this.pizzaName);
   console.log('Quantity:', this.quantity);
   console.log('Address:', this.address);
 }

}
