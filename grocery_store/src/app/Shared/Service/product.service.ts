import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
  getProductById(id: string | null): Observable<Product> {
    return this.http.get<Product>(`${this.apiurl}/${id}`);
  }
  deleteProduct(id: string) {
    return this.http.delete(`${this.apiurl}/${id}`);
  }
  postProduct(product: any) {
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    return this.http.post(this.apiurl, product, httpOptions);
  }
}
