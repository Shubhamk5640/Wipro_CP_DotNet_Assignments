import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private employees = [
    { id: 1, name: 'Shubham Kumbhar', position: 'Manager', department: 'Sales', salary: 60000 },
    { id: 2, name: 'Sanket Mane', position: 'Developer', department: 'IT', salary: 50000 },
    { id: 3, name: 'Arpan Mukharjee', position: 'Designer', department: 'Marketing', salary: 45000 }
  ];

  getEmployees() {
    return this.employees;
  }

  getEmployeeById(id: number) {
    return this.employees.find(e => e.id === id);
  }

  updateEmployee(updatedEmployee: any) {
    const index = this.employees.findIndex(e => e.id === updatedEmployee.id);
    if (index !== -1) {
      this.employees[index] = updatedEmployee;
    }
  }
}
