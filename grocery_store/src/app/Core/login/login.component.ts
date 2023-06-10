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
  products$ = this.loginService.getProd();
  
  constructor(private fb: FormBuilder, private loginService: LoginService) {}
  
  ngOnInit(): void {
    this.loginForm = this.fb.group({
      Name: new FormControl('', { validators: [Validators.required] }),
      Email: new FormControl('', { validators: [Validators.required] }),
      PhoneNumber: new FormControl('', { validators: [Validators.required] }),
      Password: new FormControl('', { validators: [Validators.required] }),
      ConfirmPassword: new FormControl('', { validators: [Validators.required] }),
    });
  }


}
