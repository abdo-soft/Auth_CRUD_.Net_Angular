
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddeditComponent } from './module/dashboard/addedit.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { DefaultComponent } from './layouts/default/default.component';
import { DashboardComponent } from './module/dashboard/dashboard.component';
import { AuthGuard } from './_helper/auth.guard';

//const routes: Routes = [
 // { path: '', component: ListComponent },
 // { path: 'employee/add', component: AddeditComponent },
 // { path: 'employee/edit/:id', component: AddeditComponent },
//];
const routes: Routes = [
  { path:"register" , component:RegisterComponent },
  { path:"login" , component:LoginComponent },
  {
    path:'',
    canActivate : [AuthGuard],
    component:DefaultComponent,
    children:[{
      path:'',
      component:DashboardComponent
    },
    {
      path : 'employee/add',
      canActivate: [AuthGuard],
      component : AddeditComponent
    },
    {
      path : 'employee/edit/:id',
      canActivate: [AuthGuard],
      component : AddeditComponent
    },
    // {
    //   path : 'edit-employee/:id',
    //   canActivate: [AuthGuard],
    //   component : EditEmployeeComponent
    // },
  ]
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
