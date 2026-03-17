import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-appointment',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './appointment.html',
  styleUrl: './appointment.css',
})
export class Appointment {
  patientName = '';
  doctor = '';
  date = '';
  consultationType = 'Online';
  symptoms = '';

  fee = 300;
  submitted = false;

  doctors = ['Dr. Sharma', 'Dr. Mehta', 'Dr. Singh'];

  updateFee() {
    this.fee = this.consultationType === 'Online' ? 300 : 500;
  }

  submitForm() {
    this.submitted = true;
  }

  get today() {
    return new Date().toISOString().split('T')[0];
  }
}
