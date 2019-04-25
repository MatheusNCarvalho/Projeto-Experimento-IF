import { NgModule } from "@angular/core";
import { RouterModule } from '@angular/router';

import { NavbarComponent } from './navbar/navbar.component';
import { FramePageComponent } from './master/frame.page';

@NgModule({
  imports: [
    RouterModule
  ],
  declarations: [
    FramePageComponent,
    NavbarComponent
  ],
  exports: [
    FramePageComponent,
    NavbarComponent
  ]
})
export class SharedModule { }