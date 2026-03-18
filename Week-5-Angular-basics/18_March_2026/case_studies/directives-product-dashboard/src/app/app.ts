import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  showProducts = true;

  products = [
    { name: 'Laptop', price: 50000, status: 'Available' },
    { name: 'Smartphone', price: 20000, status: 'out' },
    {  name: 'Tablet', price: 30000, status: 'limited' }
  ];
}
