import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../Interface/Order.interface';
import { LoginService } from './login.service';
import { UserStoreService } from './user-store.service';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  id!: string;
  constructor(
    private http: HttpClient,
    private loginService: LoginService,
    private userStore: UserStoreService
  ) {}
  apiurl = 'https://localhost:44333/api/order';

  private getUserId() {
    const nameFormToken = this.loginService.getIdFromToken();
    this.userStore.getIdFormStore().subscribe((val) => {
      this.id = val || nameFormToken;
    });
  }

  getOrder(): Observable<Order[]> {
    this.getUserId();
    return this.http.get<Order[]>(`${this.apiurl}/${this.id}`);
  }

  postOrder(order:any){
    return this.http.post(this.apiurl, order);
  }
}
