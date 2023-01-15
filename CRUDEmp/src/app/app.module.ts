import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AddeditComponent } from './module/dashboard/addedit.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtInterceptor } from './_helper/jwt.interceptor';
import { ErrorsInterceptor } from './_helper/errors.interceptor';
import { APP_BASE_HREF } from '@angular/common';
import { DefaultModule } from './layouts/default/default.module';
import { DashboardComponent } from './module/dashboard/dashboard.component';
import { RegisterComponent } from './auth/register/register.component';
import { LoginComponent } from './auth/login/login.component';
import { ToastrModule } from 'ngx-toastr';
import { ApiserviceService } from './apiservice.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
   
    AddeditComponent,
    DashboardComponent,
    RegisterComponent,
    LoginComponent,



  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
   DefaultModule,
    NgbModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorsInterceptor, multi: true },
    {provide: APP_BASE_HREF, useValue : '/' },
    {provide: ApiserviceService}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
