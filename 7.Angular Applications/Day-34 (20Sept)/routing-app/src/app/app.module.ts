import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';  // Ensure RouterModule is imported

import { AppComponent } from './app.component';
import { EmployeeListComponent } from '../employee-list/employee-list.component';
import { EmployeeComponent } from '../employee/employee.component';

// Define your routes
const routes: Routes = [
  { path: 'employee-list', component: EmployeeListComponent },
  { path: 'employee/:id', component: EmployeeComponent },
  { path: '', redirectTo: '/employee-list', pathMatch: 'full' }
];

@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    EmployeeComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),  // Add this to set up the routes
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
