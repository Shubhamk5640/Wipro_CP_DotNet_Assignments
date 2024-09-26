import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EditEmployeeComponent } from './edit-employee/edit-employee.component';

const routes: Routes = [
  { path: 'employee-list', component: EmployeeListComponent },
  { path: 'edit-employee', component: EditEmployeeComponent }, // This path is used if no ID is passed
  { path: 'edit-employee/:id', component: EditEmployeeComponent }, // This path is used if ID is passed
  { path: '', redirectTo: '/employee-list', pathMatch: 'full' },
  { path: '**', redirectTo: '/employee-list' }  // Redirect any unknown routes to the employee list
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
