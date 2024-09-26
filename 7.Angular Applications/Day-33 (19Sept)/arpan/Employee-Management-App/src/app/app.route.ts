import { Routes } from '@angular/router';
import { EmployeeListComponent } from './employee-list/emp-list.component';
import { EmployeeComponent } from './employee/emp.component';

export const routes: Routes = [
  { path: '', component: EmployeeListComponent },
  { path: 'employee/:id', component: EmployeeComponent }  // Route for a specific employee
];