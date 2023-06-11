import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../Interface/Product.interface';
import { Cart } from '../Interface/Cart.interface';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  constructor(private http: HttpClient) {}
  apiurl = 'https://localhost:44333/api/cart';

  getCart(): Observable<Cart[]> {
    return this.http.get<Cart[]>(`${this.apiurl}/${1}`);
  }
}
