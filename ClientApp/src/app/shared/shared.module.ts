import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterbarComponent } from './footerbar/footerbar.component';
import { LoaderComponent } from './loader/loader.component';
import { LoaderService } from './loader.service';

@NgModule({
  imports: [
    CommonModule,
    SharedRoutingModule
  ],
  declarations: [NavbarComponent, FooterbarComponent, LoaderComponent],
  providers: [LoaderService],
  exports: [NavbarComponent, FooterbarComponent, LoaderComponent]
})
export class SharedModule { }
