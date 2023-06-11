import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Product } from '../Interface/Product.interface';
import { Login } from '../Interface/Login.interface';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private http: HttpClient) {}
  apiurl = 'https://localhost:44333/api/UserAccount/login';

  login(loginUser: Login):Observable<any> {
    return this.http.post<any>(`${this.apiurl}`, loginUser);
  }

  storeToken(token: string) {
    localStorage.setItem('token', token);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  logout() {}
}
