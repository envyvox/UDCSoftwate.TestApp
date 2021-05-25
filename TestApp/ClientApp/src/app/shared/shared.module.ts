import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EnumToStringPipe } from "./pipes/enum-to-string.pipe";



@NgModule({
  declarations: [
    EnumToStringPipe
  ],
  imports: [
    CommonModule
  ],
  exports: [
    EnumToStringPipe
  ]
})
export class SharedModule { }
