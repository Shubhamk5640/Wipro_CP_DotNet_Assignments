import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';  // Import ActivatedRoute

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employeeId: number = 0;

  constructor(private route: ActivatedRoute) {}  // Inject ActivatedRoute

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.employeeId = +params.get('id')!;
    });
  }
}
