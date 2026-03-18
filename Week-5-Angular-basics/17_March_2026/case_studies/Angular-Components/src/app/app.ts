import { Component } from '@angular/core';
import { Home } from './components/home/home';
import { User } from './components/user/user';
import { Product } from './components/product/product';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Home, User, Product],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {}