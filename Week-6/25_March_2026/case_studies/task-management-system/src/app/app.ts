import { Component, signal } from '@angular/core';
import { RouterOutlet, RouterModule } from '@angular/router';
import { TaskFormComponent } from './components/task-form/task-form';
import { TaskListComponent } from './components/task-list/task-list';
import { FormsModule } from '@angular/forms'; // 👈 add this

@Component({
  selector: 'app-root',
  standalone: true, 
  imports: [RouterOutlet,FormsModule, RouterModule, TaskFormComponent, TaskListComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('task-management-system');
}
