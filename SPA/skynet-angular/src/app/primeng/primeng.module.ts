import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { LoginComponent } from '../login/login.component';
import { InputTextModule } from 'primeng/inputtext';
import { CheckboxModule } from 'primeng/checkbox';
import { RadioButtonModule } from 'primeng/radiobutton';

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule, 
    ButtonModule, 
    InputTextModule, 
    CheckboxModule, 
    RadioButtonModule
  ], 
  exports:[]
})
export class PrimengModule { }
