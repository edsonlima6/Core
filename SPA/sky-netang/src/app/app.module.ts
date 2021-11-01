import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {AccordionModule} from 'primeng/accordion';     //accordion and accordion tab
import {MenubarModule} from 'primeng/menubar';

import { UsersComponent } from './Core/components/users/users.component';
import { HomeComponent } from './Core/components/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule, 
    AccordionModule, MenubarModule    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
