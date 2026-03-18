import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-student-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student-dashboard.html',
  styleUrl: './student-dashboard.css',
})
export class StudentDashboard {
  students = [
    { name: 'Aman', marks: 85 },
    { name: 'Riya', marks: 45 },
    { name: 'Karan', marks: 72 },
    { name: 'Sneha', marks: 95 },
    { name: 'Arjun', marks: 30 },
  ];

  getGrade(marks: number) {
    if (marks >= 90) return 'A';
    if (marks >= 75) return 'B';
    if (marks >= 50) return 'C';
    return 'F';
  }
}