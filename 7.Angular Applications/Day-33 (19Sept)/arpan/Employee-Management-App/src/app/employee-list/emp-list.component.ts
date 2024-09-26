import { Component } from '@angular/core';
import { EmployeeComponent } from '../employee/emp.component';
import { Employee } from '../employee/employee.model';
import { CommonModule } from '@angular/common';  // Import CommonModule

@Component({
  selector: 'empList',
  standalone: true,
  imports: [CommonModule, EmployeeComponent],
  templateUrl: './emp-list.component.html',
  styleUrls: ['./emp-list.component.css']
})
export class EmployeeListComponent {
  employees: Employee[] = [
    { id: 1, name: 'Shubham Kumbhar', age: 25, salary: 100000, position: 'Software Engineer', department: 'IT' },
    { id: 2, name: 'Sanket Mane', age: 25, salary: 20000, position: 'Product Manager', department: 'Sales' },
    { id: 3, name: 'Arpan Mukharjee', age: 25, salary: 40000, position: 'Designer', department: 'Marketing' }
  ];

  selectedEmployee: Employee | null = null;
  showDetails: boolean = false; // State for toggling more details

  toggleDetails(employee: Employee): void {
    this.selectedEmployee = this.selectedEmployee === employee ? null : employee;
  }

  toggleMoreDetails(): void {
    this.showDetails = !this.showDetails; // Toggle the visibility of more details (Age, Salary)
  }
}