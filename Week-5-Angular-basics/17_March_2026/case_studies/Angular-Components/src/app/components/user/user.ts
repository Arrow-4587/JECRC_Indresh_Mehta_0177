import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user.html',
  styleUrl: './user.css',
})
export class User {
  users = ['Alice', 'Bob', 'Charlie'];

    user = {name: 'Bob', age:30};
title: any;
  getGreeting(){
    return 'Welcome to Angular ' + this.user.name;
}}

export class UserComponent {}