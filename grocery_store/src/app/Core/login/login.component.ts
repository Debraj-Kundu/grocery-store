import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { LoginService } from 'src/app/Shared/Service/login.service';

import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { User } from 'src/app/Shared/Interface/User.interface';
import { Login } from 'src/app/Shared/Interface/Login.interface';
import { Router } from '@angular/router';

const matModules = [
  MatFormFieldModule,
  MatCardModule,
  MatButtonModule,
  MatInputModule,
  MatDatepickerModule,
  MatNativeDateModule,
];

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, ...matModules],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  userLogin: Login = {
    Email: '',
    Password: '',
  };

  constructor(
    private fb: FormBuilder,
    private loginService: LoginService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      Email: new FormControl('', { validators: [Validators.required] }),
      Password: new FormControl('', { validators: [Validators.required] }),
    });
  }

  Login() {
    if (this.loginForm.valid) {
      this.userLogin.Email = this.loginForm.value.Email;
      this.userLogin.Password = this.loginForm.value.Password;
      this.loginService.login(this.userLogin).subscribe({
        next: (res) => {
          this.loginForm.reset();
          console.log('haa ');
          this.loginService.storeToken(res);
          this.router.navigate(['register']);
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
  }
}
