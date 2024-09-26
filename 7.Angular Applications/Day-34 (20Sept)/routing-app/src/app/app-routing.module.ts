import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from '../employee-list/employee-list.component';
import { EmployeeComponent } from '../employee/employee.component';

const routes: Routes = [
  { path: '', component: EmployeeListComponent }, // Employee list as default route
  { path: 'employee/:id', component: EmployeeComponent }, // Edit employee by ID
  { path: '**', redirectTo: '', pathMatch: 'full' } // Wildcard route for a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
