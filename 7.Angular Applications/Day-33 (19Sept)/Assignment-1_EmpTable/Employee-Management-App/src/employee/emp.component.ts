import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './emp.component.html', // Check this path
  styleUrls: ['./emp.component.css']   // Check this path
})

export class EmployeeComponent {
  @Input() employee: any;
  showDetails = false;

  toggleDetails() {
    this.showDetails = !this.showDetails;
  }
}
