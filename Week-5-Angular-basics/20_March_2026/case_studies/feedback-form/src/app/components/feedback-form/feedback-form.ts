import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-feedback-form',
  imports: [CommonModule, FormsModule],
  templateUrl: './feedback-form.html',
  styleUrl: './feedback-form.css',
})
export class FeedbackForm {
departments = ['Sales', 'Support', 'HR', 'IT'];
allSkilss = []
feedback = {
  name: '',
  email: '',
  department: '',
  message: ''

}
