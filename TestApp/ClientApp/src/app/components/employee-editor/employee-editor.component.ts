import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { EmployeeService, EmployeeWebModel, Gender } from "../../shared/web.api.service";
import { ActivatedRoute, Router } from "@angular/router";
import { Subject } from "rxjs";
import { MessageService, SelectItem } from "primeng/api";
import { EnumEx } from "../../shared/enum.extensions";

@Component({
  selector: 'app-employee-editor',
  templateUrl: './employee-editor.component.html',
  styleUrls: ['./employee-editor.component.css']
})
export class EmployeeEditorComponent implements OnInit, OnDestroy {
  private _destroyed: Subject<unknown>;

  form: FormGroup;
  genders: SelectItem[];
  gender = Gender;

  constructor(private _formBuilder: FormBuilder,
              private _route: ActivatedRoute,
              private _router: Router,
              private _employeeService: EmployeeService,
              private _messageService: MessageService) {
    this._destroyed = new Subject();
    this.genders = EnumEx.getNamesAndValues(Gender);
  }

  ngOnInit(): void {
    let model: EmployeeWebModel;

    this.form = this._formBuilder.group({
      id: [0, Validators.required],
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      gender: [0, Validators.required],
      city: [null, Validators.required],
      createdAt: [null],
      updatedAt: [null]
    });

    this._route.data.subscribe(x => {
      if (x.model) {
        model = x.model;
      }
      else {
        model = new EmployeeWebModel();
        model.init({id: 0});
      }

      this.form.patchValue(model);
    })
  }

  ngOnDestroy(): void {
    this._destroyed.next();
    this._destroyed.complete();
  }

  save() {
    if (this.form.invalid) return;

    const model = new EmployeeWebModel(this.form.value);

    if (model.id === 0) {
      model.createdAt = new Date();
      model.updatedAt = new Date();
      this._employeeService
        .create(model)
        .subscribe(x => {
          this._router.navigateByUrl(`/employee/editor/${x.id}`);
          this._messageService.add({severity:'success', summary:'Employee created.'});
        });
    }
    else {
      model.updatedAt = new Date();
      this._employeeService
        .update(model.id, model)
        .subscribe(x => {
          this.form.patchValue(x);
          this._messageService.add({severity:'success', summary:'Employee updated.'});
        });
    }
  }

}
