import { Component } from '@angular/core';
import { RoleDirective } from './directives/role';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RoleDirective],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {}