import { Component, OnInit } from '@angular/core';
import { Employee } from '../employee';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-all-employees',
  templateUrl: './all-employees.component.html',
  styleUrls: ['./all-employees.component.css']
})
export class AllEmployeesComponent implements OnInit {

  employees: Employee[];
  selectedEmployee: Employee;
  
  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
	  this.getEmployees();
  }
  
  onSelected(employee: Employee): void {
	  this.selectedEmployee = employee;
  }

  getEmployees(): void {
	  this.employeeService.getEmployees()
	  .subscribe(employees => this.employees = employees);
  }
}