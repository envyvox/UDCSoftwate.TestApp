import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { EmployeeService, EmployeeWebModel, IEmployeeWebModel } from "../shared/web.api.service";
import { Observable, of } from "rxjs";
import { catchError, mergeMap, take } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class EmployeeResolverService implements Resolve<IEmployeeWebModel> {

  constructor(private _employeeService: EmployeeService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot)
    : Observable<IEmployeeWebModel> | Promise<IEmployeeWebModel> | IEmployeeWebModel {
    const id = route.paramMap.get('id');
    return this._employeeService
      .get(id ? parseInt(id) : 0)
      .pipe(
        take(1),
        mergeMap(x => of(x)),
        catchError(err => of(new EmployeeWebModel()))
      );
  }
}
