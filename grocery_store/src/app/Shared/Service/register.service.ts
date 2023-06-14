import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../Interface/User.interface';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  apiurl = 'https://localhost:44333/api/UserAccount/register';

  constructor(private http: HttpClient) {}

  postUser(user: any) {
    return this.http.post<any>(`${this.apiurl}`, user);
  }
}
