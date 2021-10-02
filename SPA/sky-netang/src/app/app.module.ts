import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {AccordionModule} from 'primeng/accordion';     //accordion and accordion tab
import {MenubarModule} from 'primeng/menubar';
import { HomeComponent } from './components/home/home.component';
import { UsersComponent } from './components/users/users.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UsersComponent
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
