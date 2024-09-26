import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from '../employee.model';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent {
  employees: Employee[] = [
    {
      id: 1, firstName: 'Shubham', lastName: 'Kumbhar', email: 'sk@example.com',
      position: 'Developer', department: 'IT', age: 26, gender: 'Male',
      experience: 5, phoneNumber: '9234567890', city: 'Karad', country: 'India',
      profilePicture: null
    },
    {
      id: 2, firstName: 'Sanket', lastName: 'Mane', email: 'sm@example.com',
      position: 'Manager', department: 'HR', age: 35, gender: 'Male',
      experience: 10, phoneNumber: '9876543210', city: 'Mumbai', country: 'India',
      profilePicture: null
    },
    {
      id: 3, firstName: 'Sangram', lastName: 'Patil', email: 'sp@example.com',
      position: 'Manager', department: 'Sales', age: 35, gender: 'Male',
      experience: 10, phoneNumber: '9876543210', city: 'Mumbai', country: 'India',
      profilePicture: null
    },
    {
      id: 4, firstName: 'Swarali', lastName: 'Kadam', email: 'sk@example.com',
      position: 'Manager', department: 'HR', age: 35, gender: 'Male',
      experience: 10, phoneNumber: '9876543210', city: 'Mumbai', country: 'India',
      profilePicture: null
    },
    {
      id: 5, firstName: 'Pankaj', lastName: 'Sarnobat', email: 'ps@example.com',
      position: 'Manager', department: 'HR', age: 35, gender: 'Male',
      experience: 10, phoneNumber: '9876543210', city: 'Mumbai', country: 'India',
      profilePicture: null
    },
    // Add other employees
  ];

  constructor(private router: Router) { }

  editEmployee(employee: Employee) {
    this.router.navigate(['/edit-employee'], { state: { employee } });
  }
}
