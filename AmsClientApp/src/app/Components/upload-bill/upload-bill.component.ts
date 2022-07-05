/* eslint-disable no-debugger */
/* eslint-disable max-len */
/* eslint-disable import/no-unresolved */
/* eslint-disable no-unused-vars */
/* eslint-disable class-methods-use-this */
/* eslint-disable no-empty-function */
/* eslint-disable no-useless-constructor */
/* eslint-disable import/prefer-default-export */
import { Component, OnInit, ViewChild } from '@angular/core';
import {
  FormBuilder, FormGroup, NgForm, Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FileUploadService } from 'src/app/Services/FileUpload/file-upload.service';
import { RequestService } from 'src/app/Services/RequestOperations/CrudOperations/request.service';
import { RequestStatusService } from 'src/app/Services/RequestOperations/RequestStatusOperations/request-status.service';

@Component({
  selector: 'app-upload-bill',
  templateUrl: './upload-bill.component.html',
  styleUrls: ['./upload-bill.component.css'],
})
export class UploadBillComponent implements OnInit {
  @ViewChild('billData', {
    static: true,
  }) billData:any;

  uploadBillForm : FormGroup;

  requestDetails : any;

  uplodBillData : any;

  file: File;

  constructor(
    private form : FormBuilder,
    private requestsService : RequestService,
    private requestStatusService : RequestStatusService,
    private router : ActivatedRoute,
    private route : Router,
    private fileUploadService :FileUploadService,
    private toastrService : ToastrService,
  ) { }

  ngOnInit(): void {
    this.router.paramMap.subscribe((parameterMap) => {
      const id = parameterMap.get('id');
      this.getRequest(id);
    });
    this.uploadBillForm = this.form.group({
      requestid: [],
      purpose: [],
      comments: ['', Validators.required],
      bill: ['', Validators.required],
    });
  }

  public getRequest(id:any):void {
    this.requestsService.getRequestById(id).subscribe((response:any) => {
      this.requestDetails = response;
      this.setValue(response);
    });
  }

  private setValue(data:any) {
    this.uploadBillForm.setValue({
      requestid: data.id,
      purpose: data.purpose,
      comments: '',
      bill: '',
    });
  }

  public onSubmit():void {
    const formData = new FormData();
    formData.append('fileData', this.billData.nativeElement.files[0]);
    formData.append('requestId', this.uploadBillForm.value.requestid);
    formData.append('comments', this.uploadBillForm.value.comments);
    this.fileUploadService.uploadBill(formData).subscribe((response:any) => {
      this.uplodBillData = response;
      this.completedRequestThread(this.uploadBillForm.value.requestid);
      this.route.navigate(['makeRequest']);
      this.toastrService.success('Biill uploaded successfully, Request Completed', 'Success', { tapToDismiss: true });
    });
  }

  public completedRequestThread(id:any) {
    this.requestStatusService.setCompletedStatus(id, this.requestDetails).subscribe((response:any) => {});
  }
}
