/* eslint-disable import/prefer-default-export */
/* eslint-disable comma-dangle */
/* eslint-disable no-multiple-empty-lines */
/* eslint-disable import/no-unresolved */
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { ConfirmationPopoverModule } from 'angular-confirmation-popover';
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule } from '@angular/common/http';
import { LayoutModule } from '@angular/cdk/layout';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgxPaginationModule } from 'ngx-pagination';
import { DatePipe } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './Components/home/home.component';
import { LoginComponent } from './SharedModule/Components/login/login.component';
import { NavigationBarComponent } from './SharedModule/Components/navigation-bar/navigation-bar.component';
import { MaterialModule } from './material.module';
import { ViewRequestsComponent } from './SharedModule/Components/view-requests/view-requests.component';
import { ErrorDialogComponent } from './SharedModule/Components/error-dialog/error-dialog.component';
import { EditRequestComponent } from './SharedModule/Components/edit-request/edit-request.component';
import { ManagerComponent } from './Components/manager/manager.component';
import { PageNotFoundComponent } from './SharedModule/Components/page-not-found/page-not-found.component';
import { DetailsComponent } from './Components/details/details.component';
import { RejectedReasonComponent } from './SharedModule/Components/rejected-reason/rejected-reason.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    NavigationBarComponent,
    ViewRequestsComponent,
    ErrorDialogComponent,
    EditRequestComponent,
    ManagerComponent,
    PageNotFoundComponent,
    DetailsComponent,
    RejectedReasonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    LayoutModule,
    ReactiveFormsModule,
    MaterialModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    ConfirmationPopoverModule.forRoot({ confirmButtonType: 'danger' }),
    Ng2SearchPipeModule,
    NgxPaginationModule
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }