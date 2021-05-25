import { Component, Input, OnInit } from '@angular/core';
import { EmployeeWebModel, Gender } from "../../shared/web.api.service";

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {

  @Input() employee: EmployeeWebModel | undefined;
  gender = Gender;

  constructor() { }

  ngOnInit(): void {
  }

}
