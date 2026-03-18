import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatusColorDirective } from './directives/status-color';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, StatusColorDirective],
  templateUrl: './app.html',
})
export class App {

  students = [
    { name: 'Aman', marks: 85 },
    { name: 'Riya', marks: 45 },
    { name: 'Karan', marks: 60 }
  ];
}