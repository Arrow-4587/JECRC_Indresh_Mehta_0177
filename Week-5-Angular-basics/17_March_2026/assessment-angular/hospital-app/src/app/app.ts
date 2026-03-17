// import { Component, signal } from '@angular/core';
// import { RouterOutlet } from '@angular/router';

// @Component({
//   selector: 'app-root',
//   imports: [RouterOutlet],
//   templateUrl: './app.html',
//   styleUrl: './app.css'
// })
// export class App {
//   protected readonly title = signal('hospital-app');
// }


import { Component } from '@angular/core';
import { Appointment } from './components/appointment/appointment';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Appointment],
  template: `<app-appointment></app-appointment>`,
})
export class App {}