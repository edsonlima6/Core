import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { AngularDefaulPageComponent } from 'src/Core/Components/angular-defaul-page/angular-defaul-page.component';
import { LoginComponent } from 'src/Core/Components/login/login.component';


import { ButtonModule } from 'primeng/button';
import { StocksDailyComponent } from 'src/Core/Components/PrimeNg/stocks-daily/stocks-daily.component';
import { HttpService } from 'src/Core/Services/HttpService';
import { provideHttpClient } from '@angular/common/http';

const routes: Routes = [
  { path: 'angular-default', component:  AngularDefaulPageComponent },
  { path: 'login', component:  LoginComponent }, 
  { path: 'stocks-daily', component:  StocksDailyComponent },
]

@NgModule({
  declarations: [
    AppComponent, 
    AngularDefaulPageComponent
  ],
  imports: [
    BrowserModule, 
    RouterModule.forRoot(routes),
    ButtonModule
  ],
  exports: [RouterModule],
  providers: [
    HttpService, 
    provideHttpClient()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
