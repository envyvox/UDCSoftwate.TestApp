import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EmployeesComponent } from "./components/employees/employees.component";
import { EmployeeDetailComponent } from "./components/employee-detail/employee-detail.component";
import { EmployeeEditorComponent } from "./components/employee-editor/employee-editor.component";
import { EmployeeResolverService } from "./services/employee-resolver.service";

const routes: Routes = [
  { path: '', redirectTo: '/employee', pathMatch: 'full' },
  { path: 'employee', component: EmployeesComponent },
  { path: 'employee/:id', component: EmployeeDetailComponent },
  { path: 'employee/editor/:id', component: EmployeeEditorComponent, resolve: { model: EmployeeResolverService } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
