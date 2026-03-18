// import { Component } from '@angular/core';
// import { FormsModule } from '@angular/forms';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
@Component({
  selector: 'app-root',
  imports: [FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  //Data
  productName = "Laptop";
  price = 50000;
  quantity = 1;
  isAvailable = true;
  //isDisabled = false;
  imageUrl = "https://picsum.photos/150";

  //Two way binding fields
  customerName = '';
  address = '';

  //Methods (Event Binding)
  increaseQuantity() {
    this.quantity++;
  }

  decreaseQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  toggleAvailability() {
    this.isAvailable = !this.isAvailable;
  }

  //toggleButton(){
  //  this.isDisabled = !this.isDisabled;
  //}

  getTotal(){
    return this.price * this.quantity;
  }
}