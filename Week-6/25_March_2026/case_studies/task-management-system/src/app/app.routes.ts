import { Routes } from '@angular/router';
import { TaskListComponent } from '../app/components/task-list/task-list';
import { TaskFormComponent } from '../app/components/task-form/task-form';

export const routes: Routes = [
  { path: '', component: TaskListComponent },
  { path: 'add', component: TaskFormComponent }
];