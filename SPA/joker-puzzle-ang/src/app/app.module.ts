import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { AngularDefaulPageComponent } from 'src/Core/Components/angular-defaul-page/angular-defaul-page.component';
import { LoginComponent } from 'src/Core/Components/login/login.component';

const routes: Routes = [
  { path: 'angular-default', component:  AngularDefaulPageComponent },
  { path: 'login', component:  LoginComponent }
]

@NgModule({
  declarations: [
    AppComponent, 
    AngularDefaulPageComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule, 
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
