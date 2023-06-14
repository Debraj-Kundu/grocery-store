import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cart } from '../Interface/Cart.interface';
import { LoginService } from './login.service';
import { UserStoreService } from './user-store.service';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  id!: string;
  constructor(
    private http: HttpClient,
    private loginService: LoginService,
    private userStore: UserStoreService
  ) {}
  apiurl = 'https://localhost:44333/api/cart';

  private getUserId() {
    const nameFormToken = this.loginService.getIdFromToken();
    this.userStore.getIdFormStore().subscribe((val) => {
      this.id = val || nameFormToken;
    });
  }

  getCart(): Observable<Cart[]> {
    this.getUserId();
    return this.http.get<Cart[]>(`${this.apiurl}/${this.id}`);
  }
  postCart(cart: any) {
    return this.http.post(this.apiurl, cart);
  }
  deleteCartItem(id: string) {
    return this.http.delete(`${this.apiurl}/${id}`);
  }
}
