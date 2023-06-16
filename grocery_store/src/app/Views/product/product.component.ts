import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from 'src/app/Shared/Service/product.service';
import { LoginService } from 'src/app/Shared/Service/login.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { Product } from 'src/app/Shared/Interface/Product.interface';
import { MatCardModule } from '@angular/material/card';
import { CartService } from 'src/app/Shared/Service/cart.service';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { UserStoreService } from 'src/app/Shared/Service/user-store.service';
import { Review } from 'src/app/Shared/Interface/Review.interface';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatIconModule, MatButtonModule],
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  constructor(
    private productService: ProductService,
    private loginService: LoginService,
    private route: ActivatedRoute,
    private cartService: CartService,
    private router: Router,
    private userStore: UserStoreService
  ) {}

  id: string | null = '';
  quantity: number = 1;
  product$!: Observable<Product>;
  reviews$!: Observable<Review[]>;

  imageBaseUrl = 'https://localhost:44333/resources/';

  isLoggedIn: boolean = false;

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.product$ = this.productService.getProductById(this.id);
    this.reviews$ = this.productService
      .getProductById(this.id)
      .pipe(map((list) => list.reviews));

    this.userStore.getfullnameFormStore().subscribe((val) => {
      this.isLoggedIn = this.loginService.isLoggedIn();
    });
  }
  increase() {
    this.quantity += 1;
  }
  decrease() {
    this.quantity = Math.max(0, this.quantity - 1);
  }
  addToCart() {
    let productId = 0;
    this.product$.pipe(map((res) => res.id)).subscribe((res) => {
      productId = res;
      this.cartService
        .postCart({ productId, quantity: this.quantity })
        .subscribe((res) => {
          this.router.navigate(['/cart']);
        });
    });
  }
}
