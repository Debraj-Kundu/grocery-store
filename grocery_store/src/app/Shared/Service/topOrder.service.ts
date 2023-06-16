import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TopOrder } from '../Interface/TopOrder.interface';

@Injectable({
  providedIn: 'root',
})
export class TopOrderService {
  constructor(
    private http: HttpClient,
  ) {}

  apiurl = 'https://localhost:44333/api/toporder';

  getTopOrderedProducts(top?:number, month?:number, year?:number): Observable<TopOrder[]> {
    return this.http.get<TopOrder[]>(`${this.apiurl}?top=${top??0}&month=${month??0}&year=${year??0}`);
  }
}
