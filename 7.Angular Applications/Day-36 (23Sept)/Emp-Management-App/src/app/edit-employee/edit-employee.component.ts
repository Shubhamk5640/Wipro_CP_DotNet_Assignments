import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Employee } from '../employee.model'; // Import the Employee model
@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {
  existingEmployees: Employee[] = []; // Array to hold existing employees
  employee: Employee = new Employee(); // Employee object to bind the form data
  employeeId: number | null = null; // Variable to store employee ID from route
  onFileSelected: any;
  constructor(private router: Router, private route: ActivatedRoute) {}
  ngOnInit(): void {
    // Get the employee ID from the URL and ensure it's a valid number
    const id = this.route.snapshot.paramMap.get('id');
    this.employeeId = id ? +id : null; // Convert id to a number
     // Convert the id to a number

     if (history.state && history.state.employee) {
      this.employee = history.state.employee;
    }
    

    if (this.employeeId !== null) {
      this.employee.id = this.employeeId;
      this.fetchEmployeeData(); // Fetch employee data by ID
    }
  }
  onSubmit() {
    console.log('Updated Employee:', this.employee); 
  }
  editEmployee(employee: Employee) {
    this.router.navigate([`/edit-employee`, employee.id], {
      state: { employee }
    });
  }

  fetchEmployeeData(): void {
    // Validate if employee ID is present
    if (!this.employee.id) {
      alert('Please enter a valid Employee ID');
      return;
    }
    const empData = this.existingEmployees.find(emp => emp.id === this.employee.id);
    if (empData) {
      this.employee = { ...empData }; // Prefill form with employee data
      console.log('Employee Data Fetched:', this.employee);
    } else {
      alert('Employee not found!');
    }
  }
}
