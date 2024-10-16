import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MegaMenuModule } from 'primeng/megamenu';
import { MegaMenuComponent } from '../mega-menu/mega-menu.component';


import { ButtonModule } from 'primeng/button';
import { AvatarModule } from 'primeng/avatar';
import { TabMenuModule } from 'primeng/tabmenu';
import {ChartModule} from 'primeng/chart';
import { LineChartComponent } from '../line-chart/line-chart.component';

@NgModule({
  declarations: [
    MegaMenuComponent, 
    LineChartComponent
  ],
  imports: [
    CommonModule,
    MegaMenuModule, 
    ButtonModule,
    AvatarModule,
    TabMenuModule, 
    ChartModule
  ],
  exports: [
    MegaMenuComponent,
    LineChartComponent
  ]
})
export class PrimengModuleModule { }
