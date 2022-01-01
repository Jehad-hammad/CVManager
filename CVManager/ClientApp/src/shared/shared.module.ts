import { ModuleWithProviders, NgModule } from '@angular/core';

import { MaterialModule } from './material.module';
import { CommonModule } from '@angular/common';
import { SimpleNotificationsModule } from 'angular2-notifications';
import { NgxSpinnerModule } from "ngx-spinner";

@NgModule({
    imports: [
        MaterialModule,
        CommonModule,
        NgxSpinnerModule,
        SimpleNotificationsModule.forRoot()

  ],
    declarations: [
  ],
  exports: [
    MaterialModule,
  ],
  providers: [
    ],
    entryComponents: [
        
    ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
        ngModule: SharedModule,
        providers: [
        ],
    };
  }
}
