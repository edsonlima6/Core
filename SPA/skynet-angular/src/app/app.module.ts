import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { DefaultPageComponent } from './default-page/default-page.component';
import { UserListComponent } from './Core/Components/user-list/user-list.component';
import { UserroutingModule } from './Core/Components/User/userrouting/userrouting.module';
import { CreateUserComponent } from './Core/Components/User/create-user/create-user.component';
import { PrimengModule } from './primeng/primeng.module';
import { DogBreedService } from './Core/Services/dog-breed.service';



@NgModule({
  declarations: [
    AppComponent,
    DefaultPageComponent,
    UserListComponent,
    CreateUserComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    UserroutingModule,
    PrimengModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent}, 
      {path: 'defaultPage', component: DefaultPageComponent},

    ])
  ],
  providers: [DogBreedService],
  bootstrap: [AppComponent], 
  exports:[]
})
export class AppModule { }
