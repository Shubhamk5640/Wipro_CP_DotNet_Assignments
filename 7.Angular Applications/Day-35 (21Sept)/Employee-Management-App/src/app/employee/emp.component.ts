import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';  // Import CommonModule
import { Employee } from '../employee/employee.model';  // Ensure the correct import

@Component({
  selector: 'emp',
  standalone: true,  // Declare this component as standalone
  imports: [CommonModule],  // Add CommonModule here
  templateUrl: './emp.component.html',
  styleUrls: ['./emp.component.css']
})
export class EmployeeComponent {
  @Input() employee: Employee | null = null;
}
