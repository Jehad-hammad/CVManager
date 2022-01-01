import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatMenuTrigger } from '@angular/material/menu';
import { MatSidenav } from '@angular/material/sidenav';
import { NavService } from './services/nav.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements AfterViewInit{
  title = 'app';
  @ViewChild('sidenav', { static: false }) appDrawer: ElementRef;
  public sideNavStatus = false;
  public showFlag: boolean = false;
  @ViewChild(MatSidenav, { static: false }) sidenav: MatSidenav;
  @ViewChild('menuTrigger', { static: false }) menuTrigger: MatMenuTrigger;

  constructor(
    private navService: NavService,
  ) {

  }
  ngAfterViewInit() {
    this.navService.appDrawer = this.appDrawer;
  }
  IsSidebarOpened() {
    const isOpened = this.sidenav ? this.sidenav.opened : false;
    return isOpened;
  }
  toggle() {
    this.sidenav.toggle();
    this.sideNavStatus = this.sidenav.opened;
  }

  openSideNav() {
    if (!this.sidenav.opened) {
      this.sidenav.toggle();
    }
  }
  closeSideNav() {
    if (this.sidenav.opened) {
      this.sidenav.toggle();
    }
  }
}
