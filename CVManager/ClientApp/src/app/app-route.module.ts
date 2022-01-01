import { CdkVirtualScrollViewport } from '@angular/cdk/scrolling';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CvFormComponent } from './cv-form/cv-form.component';
import { CvListComponent } from './cv-list/cv-list.component';
import { ViewCvComponent } from './view-cv/view-cv.component';

const appRoutes: Routes = [
  { path: '', component:CvListComponent},
  { path: 'list',component:CvListComponent },
  { path: 'cv-form', component: CvFormComponent },
  { path: 'cv-edit/:id', component: CvFormComponent },
  { path: 'cv-view/:id', component: ViewCvComponent },
]

@NgModule({
  imports: [RouterModule.forRoot(appRoutes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRouteModule {
}
