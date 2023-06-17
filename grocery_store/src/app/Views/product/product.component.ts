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
import { ToastService } from 'src/app/Shared/Service/toast.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReviewService } from 'src/app/Shared/Service/review.service';

const matModules = [
  MatFormFieldModule,
  MatInputModule,
  MatCardModule,
  MatIconModule,
  MatButtonModule,
];

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, ...matModules],
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
    private userStore: UserStoreService,
    private toast: ToastService,
    private fb: FormBuilder,
    private reviewService: ReviewService
  ) {}

  id: string | null = '';
  quantity: number = 1;
  product$!: Observable<Product>;
  reviews$!: Observable<Review[]>;

  reviewForm!: FormGroup;
  userReview: Review = {
    comment: '',
    productId: 0,
    username: '',
    customerId: 0,
    createdOnDate: new Date(),
    id: 0,
  };

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

    this.reviewForm = this.fb.group({
      comment: new FormControl(''),
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
        .subscribe({
          next: (res) => {
            this.router.navigate(['/cart']);
            this.toast.successToast('Added to cart');
          },
          error: (err) => {
            this.toast.errorToast('Error occured');
          },
        });
    });
  }
  postReview() {
    if (this.reviewForm.value.comment.length > 0) {
      this.userReview.comment = this.reviewForm.value.comment;
      this.userReview.productId = 0 + +(this.id ?? '');
      this.reviewService.postReview(this.userReview).subscribe({
        next: (res) => {
          this.reviews$ = this.productService
            .getProductById(this.id)
            .pipe(map((list) => list.reviews));
          this.toast.successToast('Review added successfully');
        },
        error: (err) => {
          this.toast.errorToast('An error occured');
        },
      });
    }
  }
}
