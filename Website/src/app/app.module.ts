import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AppBootstrapModule } from './app-bootstrap/app-bootstrap.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { CropsComponent } from './crops/crops.component';
import { AppRoutingModule } from './app-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';

import { environment } from '../environments/environment';
import { GardensComponent } from './gardens/gardens.component';
import { CropDetailComponent } from './crops/crop-detail.component';
import { GardenDetailComponent } from './gardens/garden-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    CropsComponent,
    DashboardComponent,
    GardensComponent,
    CropDetailComponent,
    GardenDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    AppBootstrapModule,
    FontAwesomeModule,
    BsDatepickerModule,
    BrowserAnimationsModule,
    NoopAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
