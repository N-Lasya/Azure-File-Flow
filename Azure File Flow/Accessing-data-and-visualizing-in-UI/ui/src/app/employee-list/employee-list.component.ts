import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Employee } from '../employee model';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  providers: [DatePipe]
})
export class EmployeeListComponent implements OnInit {
  
  employees: Employee[] = [];
displayedColumns: any;

  constructor(private employeeService: EmployeeService) { }
  
  ngOnInit(): void {
    this.employeeService.getEmployees().subscribe(
      (data: Employee[]) => {
        this.employees = data;
      },
      (error: any) => {
        console.log('Error fetching employees', error);
      }
    );
  }
   
  highlightRow(event: Event){
    const rowElement = event.target as HTMLElement;
    rowElement.classList.add('highlighted-row');
  }

  unhighlightRow(event: Event){
    const rowElement = event.target as HTMLElement;
    rowElement.classList.remove('highlighted-row');
  }



}
