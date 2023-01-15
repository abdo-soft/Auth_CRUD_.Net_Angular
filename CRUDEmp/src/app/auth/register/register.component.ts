import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  User: any = ['Admin', 'Author', 'Reader'];


  registerUserData :any = {};

  loginForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';


  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthService
  ) {

    this.loginForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],

  });

    if (this.authenticationService.currentUserValue) {
      this.router.navigate(['/']);
  }

  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      email: ['', Validators.required],
  });

  }


  get f() { return this.loginForm.controls; }

  onSubmit() {
      this.submitted = true;

      // stop here if form is invalid
      if (this.loginForm.invalid) {
          return;
      }

      this.loading = true;
      this.authenticationService.register(this.f['username'].value, this.f['password'].value,this.f['email'].value)
          .pipe(first())
          .subscribe({
              next: () => {
                  // get return url from route parameters or default to '/'
                  const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
                  this.router.navigate([returnUrl]);
              },
              error: error => {
                  this.error = error;
                  this.loading = false;
              }
          });

}

}
