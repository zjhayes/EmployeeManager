import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from './employee';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }
	
	private employeeApiUrl='http://localhost:53457/api/v1/employees';
	
	public getEmployees(): Observable<Employee[]> {
		return this.http.get<Employee[]>(this.employeeApiUrl);
	}
}
