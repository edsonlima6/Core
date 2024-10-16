import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideRouter, Routes, withComponentInputBinding } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PrimengModuleModule } from 'src/Core/Components/PrimeNg/primeng-module/primeng-module.module';
import { HomeDashboardComponent } from 'src/Core/Components/home-dashboard/home-dashboard.component';
import { AssetComponent } from 'src/Core/Components/asset/asset.component';


export const routes: Routes = [
 
];

@NgModule({
  declarations: [
    AppComponent,
    HomeDashboardComponent,
    AssetComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    PrimengModuleModule
  ],
  providers: [
    provideRouter(routes, withComponentInputBinding()),
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
