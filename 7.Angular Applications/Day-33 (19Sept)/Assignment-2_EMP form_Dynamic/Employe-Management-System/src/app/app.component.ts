import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  employee = {
    firstName: '',
    middleName: '',
    lastName: '',
    gender: '',
    country: '',
    dob: '',
    age: null,
    password: '',
    department: ''
  };
}

