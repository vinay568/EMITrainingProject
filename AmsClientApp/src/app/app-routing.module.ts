/* eslint-disable import/no-unresolved */
/* eslint-disable import/prefer-default-export */
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailsComponent } from './Components/ManagerComponents/details/details.component';
import { EditRequestComponent } from './Components/edit-request/edit-request.component';
import { ForgotPasswordComponent } from './SharedModule/Components/forgot-password/forgot-password.component';
import { HomeComponent } from './Components/home/home.component';

import { LoginComponent } from './Components/login/login.component';
import { ManagerComponent } from './Components/ManagerComponents/manager/manager.component';
import { PageNotFoundComponent } from './SharedModule/Components/page-not-found/page-not-found.component';
import { UploadBillComponent } from './Components/upload-bill/upload-bill.component';
import { ViewRequestsComponent } from './Components/view-requests/view-requests.component';
import { AuthGuard } from './Guards/auth.guard';
import { AuthroleGuard } from './Guards/authrole.guard';

const routes: Routes = [

  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'makeRequest', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'viewRequest', component: ViewRequestsComponent, canActivate: [AuthGuard] },
  { path: 'editRequest/:id', component: EditRequestComponent, canActivate: [AuthGuard] },
  { path: 'employeeRequests', component: ManagerComponent, canActivate: [AuthroleGuard] },
  { path: 'requestsDetails', component: DetailsComponent, canActivate: [AuthGuard] },
  { path: 'uploadBill/:id', component: UploadBillComponent, canActivate: [AuthGuard] },
  { path: 'forgotPassword', component: ForgotPasswordComponent },
  { path: '**', component: PageNotFoundComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
