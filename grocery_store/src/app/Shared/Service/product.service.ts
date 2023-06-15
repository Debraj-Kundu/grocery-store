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
  postProduct(product: Product) {
    let formData = new FormData();
    formData.append("name", product.name);
    formData.append("description", product.description);
    formData.append("price", ''+product.price);
    formData.append("discount", ''+product.discount);
    formData.append("categoryId", ''+product.categoryId);
    formData.append("availableQuantity", ''+product.availableQuantity);
    formData.append("productImage", product.productImage);
    formData.append("imageFile", product.imageFile??"");
    formData.append("specification", product.specification);

    return this.http.post(this.apiurl, formData);
  }
}
