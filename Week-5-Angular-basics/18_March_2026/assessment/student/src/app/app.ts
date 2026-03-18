import { Component } from '@angular/core';
import { StudentDashboard } from './components/student-dashboard/student-dashboard';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [StudentDashboard],
  template: `<app-student-dashboard></app-student-dashboard>`,
})
export class App {}