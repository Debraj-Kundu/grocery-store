import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Product } from '../Interface/Product.interface';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private http: HttpClient) {}
  apiurl = 'https://localhost:44333/api/product/';


  login() {
    
  }

  logout() {
    
  }

  getProd() : Observable<Product[]>{
    return this.http.get<Product[]>(this.apiurl);
  }
}
