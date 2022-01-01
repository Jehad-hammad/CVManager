import { OnInit, ViewChild } from '@angular/core';
import { Component } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseService } from '../../shared/services/base.service';
import { NotificationServiceService } from '../../shared/services/notification-service.service';

@Component({
    selector: 'app-cv-list',
    templateUrl: './cv-list.component.html',
    styleUrls: ['./cv-list.component.scss']
})
/** CvList component*/
export class CvListComponent implements OnInit{
  /** CvList ctor */
  dataSource: MatTableDataSource<any>;
  displayedColumns: string[] = ['FullName', 'Company', 'Actions'];

  CVList = []

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private baseService: BaseService,
    private notificationService: NotificationServiceService,
    private spinner:NgxSpinnerService
  ) {

  }

  ngOnInit() {
    this.getCVsList();
  }

  getCVsList() {
    this.baseService.getList('CV',null).subscribe(res => {
      this.CVList = res as any[]
      this.dataSource = new MatTableDataSource(this.CVList)
      this.dataSource.filterPredicate = function (data, filter: string): boolean {
        return data.personalInformation.fullName.toLowerCase().includes(filter)
          || data.experinceInformation.companyName.toLowerCase().includes(filter)

      };
    })
  }

  onSearch(filter: string) {
   this.dataSource.filter = filter.toLowerCase().trim()
  }

  onDelete(entity) {
    this.spinner.show()
    this.baseService.removeItem('CV', entity).subscribe(res => {
      this.getCVsList();
      this.notificationService.showNotification('CV', 'The item removed successfully', 'success')
      this.spinner.hide()
    }, error => {
      this.spinner.hide()
      this.notificationService.showNotification('error','something went wrong','error')
    })
  }
}
