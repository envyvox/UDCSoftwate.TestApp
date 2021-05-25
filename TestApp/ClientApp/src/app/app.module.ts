import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeDetailComponent } from './components/employee-detail/employee-detail.component';
import { EmployeesComponent } from './components/employees/employees.component';
import { HttpClientModule } from "@angular/common/http";
import { EnumToStringPipe } from './shared/pipes/enum-to-string.pipe';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { EmployeeEditorComponent } from './components/employee-editor/employee-editor.component';
import { DropdownModule } from "primeng/dropdown";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ButtonModule } from "primeng/button";
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { InputTextModule } from 'primeng/inputtext';
import { ListboxModule } from "primeng/listbox";
import { ToastModule } from 'primeng/toast';
import { MessageService } from "primeng/api";

@NgModule({
  declarations: [
    AppComponent,
    EmployeeDetailComponent,
    EmployeesComponent,
    EnumToStringPipe,
    EmployeeEditorComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    DropdownModule,
    ButtonModule,
    ConfirmDialogModule,
    InputTextModule,
    ListboxModule,
    ToastModule
  ],
  providers: [MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
