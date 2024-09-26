import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.css']
})
export class CreateEmployeeComponent {
  employeeForm: FormGroup;

  constructor(private fb: FormBuilder, private employeeService: EmployeeService) {
    this.employeeForm = this.fb.group({
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      age: ['', [Validators.required, Validators.min(18), Validators.max(65)]],
      salary: ['', Validators.required],
      gender: ['', Validators.required],
      country: ['', Validators.required]
    });
  }

  // Getters for form controls for easy access in the template
  get firstName() { return this.employeeForm.get('firstName'); }
  get lastName() { return this.employeeForm.get('lastName'); }
  get age() { return this.employeeForm.get('age'); }
  get salary() { return this.employeeForm.get('salary'); }
  get gender() { return this.employeeForm.get('gender'); }
  get country() { return this.employeeForm.get('country'); }

  onSubmit(): void {
    if (this.employeeForm.valid) {
      this.employeeService.addEmployee(this.employeeForm.value).subscribe(response => {
        console.log('Employee added successfully!', response);
      }, error => {
        console.error('Error adding employee', error);
      });
    } else {
      console.log('Form is invalid');
    }
  }
}
