import { Routes } from '@angular/router';
import { EmployeeList } from './employees/employee-list/employee-list';
import { Login } from './auth/login/login';
import { authGuard } from './core/guarads/auth-guard';

export const routes: Routes = [
  { path: 'employees', component: EmployeeList, canActivate: [authGuard] },
  { path: 'login', component: Login },
  { path: '', redirectTo: '/employees', pathMatch: 'full' }
];
