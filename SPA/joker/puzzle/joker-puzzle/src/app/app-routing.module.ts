import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssetComponent } from 'src/Core/Components/asset/asset.component';
import { HomeDashboardComponent } from 'src/Core/Components/home-dashboard/home-dashboard.component';

const routes: Routes = [
  { path: 'dashboard', component: HomeDashboardComponent },
  { path: 'assets', component: AssetComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
