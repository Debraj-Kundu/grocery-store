import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../Interface/Product.interface';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private http: HttpClient) {}
  apiurl = 'https://localhost:44333/api/product';

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiurl);
  }
}
