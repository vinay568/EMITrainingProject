/* eslint-disable import/no-unresolved */
/* eslint-disable import/prefer-default-export */
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailsComponent } from './Components/details/details.component';
import { EditRequestComponent } from './Components/edit-request/edit-request.component';
import { HomeComponent } from './Components/home/home.component';

import { LoginComponent } from './Components/login/login.component';
import { ManagerComponent } from './Components/manager/manager.component';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';
import { ViewRequestsComponent } from './Components/view-requests/view-requests.component';

const routes: Routes = [

  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'makeRequest', component: HomeComponent },
  { path: 'viewRequest', component: ViewRequestsComponent },
  { path: 'editRequest/:id', component: EditRequestComponent },
  { path: 'employeeRequests', component: ManagerComponent },
  { path: 'requestsDetails', component: DetailsComponent },
  { path: '**', component: PageNotFoundComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
