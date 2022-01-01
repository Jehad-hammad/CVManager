import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { FormControl, FormGroup, MaxLengthValidator, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseService } from '../../shared/services/base.service';
import { NotificationServiceService } from '../../shared/services/notification-service.service';

@Component({
    selector: 'app-cv-form',
    templateUrl: './cv-form.component.html',
    styleUrls: ['./cv-form.component.scss']
})
/** CvForm component*/
export class CvFormComponent implements OnInit {
  /** CvForm ctor */
  public cvId;
  public isEdit: boolean = false;

  cvForm = new FormGroup({
    id: new FormControl(0),
    name: new FormControl('',Validators.required),
    personalInformationId: new FormControl(0),
    experinceInformationId:new FormControl(0)
  })

  experienceInformationForm = new FormGroup({
    id: new FormControl(0),
    companyName: new FormControl('',[Validators.required, Validators.maxLength(20)]),
    city: new FormControl(),
    compnayField: new FormControl(),

  })

  personalInformationForm = new FormGroup({
    id: new FormControl(0),
    fullName: new FormControl('',Validators.required),
    cityName: new FormControl(),
    email: new FormControl('', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]),
    mobileNumber: new FormControl('', [Validators.required, Validators.pattern(/^07[789]\d{7}$/g)]),

  })
  
  constructor(
    public notificationService: NotificationServiceService,
    private baseService: BaseService,
    private activatedRoute: ActivatedRoute,
    private route: Router,
    private spinner:NgxSpinnerService
  ) {

  }

  ngOnInit() {
    this.activatedRoute.params.subscribe(param => {
      this.cvId = param.id
      if (this.cvId) {
        this.isEdit = true
        this.getCvById();
      }
    })
  }

  getCvById() {
    this.baseService.getById('CV', this.cvId).subscribe(res => {
      this.cvForm.patchValue(res as any)
      this.personalInformationForm.patchValue((res as any).personalInformation)
      this.experienceInformationForm.patchValue((res as any).experinceInformation)
    })
  }

  onSubmit() {
    if (this.personalInformationForm.invalid || this.experienceInformationForm.invalid || this.cvForm.invalid) {

      this.cvForm.markAllAsTouched()
      this.experienceInformationForm.markAllAsTouched()
      this.personalInformationForm.markAllAsTouched()
      this.notificationService.showNotification('Form Invalid', 'Please make sure all fields are valid', 'error')

    } else if (this.cvForm.get('id').value > 0) {

      this.spinner.show()
      const cvObject = this.cvForm.getRawValue()
      cvObject.experinceInformation = this.experienceInformationForm.getRawValue();
      cvObject.personalInformation = this.personalInformationForm.getRawValue()
      this.baseService.Edit('CV', cvObject).subscribe(res => {
        this.spinner.hide()
        this.notificationService.showNotification('Sucess', 'Your Request has been submitted successfully', 'success')
        this.route.navigate(['/list'])
      }, error => {
        this.spinner.hide()
        this.notificationService.showNotification('Error','Something went wrong while processing your request','error')
      })

    } else {

      this.spinner.show()
      const cvObject = this.cvForm.getRawValue()
      cvObject.experinceInformation = this.experienceInformationForm.getRawValue();
      cvObject.personalInformation = this.personalInformationForm.getRawValue()
      this.baseService.post('CV', cvObject).subscribe(res => {
        this.spinner.hide()
        this.notificationService.showNotification('Sucess', 'Your Request has been submitted successfully', 'success')
        this.route.navigate(['/list'])

      }, error => {
        this.spinner.hide()
        this.notificationService.showNotification('Error', 'Something went wrong while processing your request', 'error')
      })
    }


  }
}
