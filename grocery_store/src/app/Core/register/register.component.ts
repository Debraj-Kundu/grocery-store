import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { User } from 'src/app/Shared/Interface/User.interface';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { LoginService } from 'src/app/Shared/Service/login.service';
import { RegisterService } from 'src/app/Shared/Service/register.service';
import { Router } from '@angular/router';
import { ToastService } from 'src/app/Shared/Service/toast.service';

const matModules = [
  MatFormFieldModule,
  MatCardModule,
  MatButtonModule,
  MatInputModule,
  MatDatepickerModule,
  MatNativeDateModule,
];

@Component({
  selector: 'app-register',
  standalone: true,
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  imports: [CommonModule, ReactiveFormsModule, FormsModule, ...matModules],
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  userInfo: User = {
    id: 0,
    Name: '',
    Email: '',
    PhoneNumber: '',
    Password: '',
    ConfirmPassword: '',
    IsAdmin: false,
  };

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private toast:ToastService,
    private registerService: RegisterService
  ) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      Name: new FormControl('', { validators: [Validators.required] }),
      Email: new FormControl('', { validators: [Validators.required] }),
      PhoneNumber: new FormControl('', { validators: [Validators.required] }),
      Password: new FormControl('', { validators: [Validators.required] }),
      ConfirmPassword: new FormControl('', {
        validators: [Validators.required],
      }),
    });
  }

  register() {
    if (this.registerForm.valid) {
      this.userInfo.Name = this.registerForm.value.Name;
      this.userInfo.Email = this.registerForm.value.Email;
      this.userInfo.PhoneNumber = ''+this.registerForm.value.PhoneNumber;
      this.userInfo.Password = this.registerForm.value.Password;
      this.userInfo.ConfirmPassword = this.registerForm.value.ConfirmPassword;

      this.registerService.postUser(this.userInfo).subscribe({
        next: (res) => {
          console.log(res);
          this.registerForm.reset();
          this.toast.successToast('SignUp Successful!');
          this.router.navigate(['home']);
        },
        error: (err) => {
          console.log(err);
          this.toast.errorToast('SignUp Failed!');
        },
      });
    }
  }
}
