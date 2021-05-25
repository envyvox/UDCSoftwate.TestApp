import { Component, OnInit } from '@angular/core';
import { EmployeeService, EmployeeWebModel } from "../../shared/web.api.service";
import { Router } from "@angular/router";
import { ConfirmationService, MessageService } from "primeng/api";

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
  providers: [ConfirmationService]
})
export class EmployeesComponent implements OnInit {

  selectedEmployee?: EmployeeWebModel;
  employees: EmployeeWebModel[];

  constructor(private _employeeService: EmployeeService,
              private _router: Router,
              private _confirmationService: ConfirmationService,
              private _messageService: MessageService) { }

  ngOnInit(): void {
    this.getEmployees();
  }

  onSelect(employee: EmployeeWebModel) : void {
    this.selectedEmployee = employee;
  }

  getEmployees(): void {
    this._employeeService
      .list()
      .subscribe(x => this.employees = x);
  }

  editEmployee(employee: EmployeeWebModel) {
    this._router.navigateByUrl(`/employee/editor/${employee.id}`);
  }

  confirmDeleteEmployee(employee: EmployeeWebModel) {
    this._confirmationService.confirm({
      message: 'Are you sure, you want to delete selected employee?',
      accept: () => {
        this._employeeService
          .delete(employee.id)
          .subscribe(() => {
            this.getEmployees();
            this._messageService.add({severity:'success', summary:'Employee deleted.'});
          });
      }
    });
  }
}
