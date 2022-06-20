/* eslint-disable no-underscore-dangle */
/* eslint-disable no-alert */
/* eslint-disable no-console */
/* eslint-disable no-unused-vars */
/* eslint-disable no-empty-function */
/* eslint-disable no-useless-constructor */
/* eslint-disable import/prefer-default-export */
/* eslint-disable import/no-unresolved */
import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder, FormGroup, Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RequestsModel } from 'src/app/Models/requests.model';
import { RequestService } from 'src/app/Services/request.service';

@Component({
  selector: 'app-edit-request',
  templateUrl: './edit-request.component.html',
  styleUrls: ['./edit-request.component.css'],
})
export class EditRequestComponent implements OnInit {
  requestId:any;

  requestDetails:any;

  editRequestForm: FormGroup;

  approver:any;

  formattedDate:any;

  constructor(
private route:Router,
private formBuilder: FormBuilder,
private requestService : RequestService,
private toastrService : ToastrService,
private _router : ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this._router.paramMap.subscribe((parameterMap) => {
      const id = parameterMap.get('id');
      this.getRequest(id);
    });

    this.editRequestForm = this.formBuilder.group({
      purpose: ['', Validators.required],
      approver: ['', Validators.required],
      estimatedCost: ['', Validators.required],
      advanceAmount: ['', Validators.required],
      description: ['', Validators.required],
      planDate: ['', Validators.required],
    });
  }

  public getRequest(id:any) {
    this.requestService.getRequestById(id).subscribe((response:any) => {
      this.requestDetails = response;
      const date = new Date(response.planDate);
      const format = 'yyyy-MM-dd';
      const locale = 'en-US';
      response.planDate = formatDate(date, format, locale);
      this.patchValue(response);
    }, (error) => { console.log(error); });
  }

  private patchValue(data:RequestsModel) {
    this.editRequestForm.patchValue({

      purpose: data.purpose,
      approver: data.approver,
      estimatedCost: data.estimatedCost,
      advanceAmount: data.advanceAmount,
      description: data.description,
      planDate: data.planDate,
    });
  }

  public onSubmit(form:any) {
    this.requestService.editRequest(form, this.requestDetails.id).subscribe((response:any) => {
      this.toastrService.success('Request updated successfully');
      this.route.navigate(['/viewRequest']);
    }, (error) => { console.log(error); });
  }

  public onCancel() {
    this.route.navigate(['/viewRequest']);
  }
}
