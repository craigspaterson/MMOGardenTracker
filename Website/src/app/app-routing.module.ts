import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { GardensComponent } from './gardens/gardens.component';
import { GardenDetailComponent } from './gardens/garden-detail.component';
import { CropsComponent } from './crops/crops.component';
import { CropDetailComponent } from './crops/crop-detail.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'gardens', component: GardensComponent },
  { path: 'gardens/garden/:id', component: GardenDetailComponent },
  { path: 'crops', component: CropsComponent },
  { path: 'crops/crop/:id', component: CropDetailComponent },
  { path: 'crops/crop/new', component: CropDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
