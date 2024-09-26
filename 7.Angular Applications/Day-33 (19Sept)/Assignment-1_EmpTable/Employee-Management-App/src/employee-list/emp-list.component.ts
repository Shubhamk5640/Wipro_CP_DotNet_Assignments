import { Component } from '@angular/core';

@Component({
  selector: 'app-employee-list',
  templateUrl: './emp-list.component.html',
})
export class EmployeeListComponent {
  employees = [
    { id: 1, name: 'John Doe', position: 'Manager', department: 'Sales', showDetails: false },
    { id: 2, name: 'Peter Parker', position: 'Designer', department: 'Marketing', showDetails: false },
    { id: 3, name: 'Tarwe Smith', position: 'Developer', department: 'IT', showDetails: false },
  ];
}
