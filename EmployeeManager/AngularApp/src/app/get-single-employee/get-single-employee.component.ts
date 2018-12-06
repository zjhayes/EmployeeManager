import { Component, Input, OnInit } from '@angular/core';
import { Employee } from '../employee';

@Component({
  selector: 'app-get-single-employee',
  templateUrl: './get-single-employee.component.html',
  styleUrls: ['./get-single-employee.component.css']
})
export class GetSingleEmployeeComponent implements OnInit {
	@Input() employee: Employee
	
  constructor() { }

  ngOnInit() {
  }

}
