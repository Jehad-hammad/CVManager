import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseService } from '../../shared/services/base.service';

@Component({
    selector: 'app-view-cv',
    templateUrl: './view-cv.component.html',
    styleUrls: ['./view-cv.component.scss']
})
/** ViewCv component*/
export class ViewCvComponent implements OnInit{
  /** ViewCv ctor */
  public CvId
  public CV
  constructor(
    private activatedRoute: ActivatedRoute,
    private baseService:BaseService
  ) {

  }

  ngOnInit() {
    this.activatedRoute.params.subscribe(param => {
      this.CvId = param.id
      if (this.CvId) {
        this.getCvId()
      }
    })
  }

  getCvId() {
    this.baseService.getById('CV', this.CvId).subscribe(res => {
      this.CV = res as any;
    })
  }
}
