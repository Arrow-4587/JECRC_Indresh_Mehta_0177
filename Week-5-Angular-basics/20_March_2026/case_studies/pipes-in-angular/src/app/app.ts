import {AsyncPipe, CommonModule, DatePipe, KeyValuePipe} from '@angular/common';
import { Component, signal } from '@angular/core';
import { CustomCurrencyPipe } from './custom-currency-pipe';
import { of } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [AsyncPipe, CommonModule, DatePipe, KeyValuePipe, CustomCurrencyPipe],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  today = new Date();

  data$ = of([
    { 
    id: 1,
    ProductName: 'Laptop',
    price: 50000,
    status: 'Delivered',    
    },
    {
    id: 2,
    ProductName: 'Mobile',
    price: 20000,
    status: 'pending',
    }
  ]);

  product = {
    name: 'Laptop',
    price: 50000
  };
}
