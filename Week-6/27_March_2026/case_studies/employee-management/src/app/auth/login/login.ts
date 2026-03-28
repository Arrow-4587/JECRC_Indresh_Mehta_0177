import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-login',
  imports: [ FormsModule],
  template: `
  <h2>Login</h2>
  <input [(ngModel)] = "username" placeholder="Username"> 
  <input [(ngModel)] = "password" placeholder="password" type="password">
  <button (click)="login()">Login</button>` 
  ,
  styleUrl: './login.css',
})
export class Login {
  username = '';
  password = '';

  constructor(private authService: AuthService, private router: Router){}

  login(){
    if(this.authService.login(this.username, this.password)){
      this.router.navigate(['/employees']);
    } else {
      alert('Invalid credentials');
    }
  }
}
