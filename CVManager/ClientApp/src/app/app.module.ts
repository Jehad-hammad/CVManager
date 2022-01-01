import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from '../shared/shared.module';
import { AppRouteModule } from './app-route.module';
import { CvFormComponent } from './cv-form/cv-form.component';
import { CvListComponent } from './cv-list/cv-list.component';
import { SimpleNotificationsModule } from 'angular2-notifications';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NavService } from './services/nav.service';
import { ViewCvComponent } from './view-cv/view-cv.component';

@NgModule({
  declarations: [
    AppComponent,
    CvFormComponent,
    CvListComponent,
    ViewCvComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    SharedModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    AppRouteModule,
    SimpleNotificationsModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    NavService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
