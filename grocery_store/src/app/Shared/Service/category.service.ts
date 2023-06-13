import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../Interface/Category.interface';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(private http: HttpClient) {}
  apiurl = 'https://localhost:44333/api/category';

  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiurl);
  }
}