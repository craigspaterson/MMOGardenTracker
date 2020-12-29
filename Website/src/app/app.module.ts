import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AppBootstrapModule } from './app-bootstrap/app-bootstrap.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
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

    /*
    // The HttpClientInMemoryWebApiModule module intercepts HTTP requests
    // and returns simulated server responses.
    // Remove it when a real server is ready to receive requests.
    environment.production
      ? []
      : HttpClientInMemoryWebApiModule.forRoot(InMemoryDataService, {
          dataEncapsulation: false
        })
    */
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
