import { Component } from '@angular/core';
import { EmployeeListComponent } from './employee-list/emp-list.component';  // Import the Employee List component

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [EmployeeListComponent]  // Import the EmployeeListComponent
})
export class AppComponent {
  title = 'Employee Management App';
}