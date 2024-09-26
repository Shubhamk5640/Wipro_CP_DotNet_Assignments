import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router'; // Import RouterModule
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
//import { EmployeeFormComponent } from './employee-form/employee-form.component';

import { EmployeeFormComponent } from '../employee-form/employee-form.component';

// Define your routes here
const routes: Routes = [
  { path: 'employee-form', component: EmployeeFormComponent },
  // Add more routes as needed
];

@NgModule({
  declarations: [
    AppComponent,
    EmployeeFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes)  // Add RouterModule here
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
