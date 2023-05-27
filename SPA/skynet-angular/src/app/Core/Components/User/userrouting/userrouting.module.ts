import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UserListComponent } from '../../user-list/user-list.component';
import { CreateUserComponent } from '../create-user/create-user.component';

const routes: Routes = [
  { path: "users-list", component: UserListComponent},
  { path: "create-user", component: CreateUserComponent}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ], 
  exports: [RouterModule]
})
export class UserroutingModule { }
