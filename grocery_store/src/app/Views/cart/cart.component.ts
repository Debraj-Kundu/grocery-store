import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartService } from 'src/app/Shared/Service/cart.service';

import { MatCardModule } from '@angular/material/card';
import { Cart } from 'src/app/Shared/Interface/Cart.interface';
import { Observable } from 'rxjs';
import { OrderService } from 'src/app/Shared/Service/order.service';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { ToastService } from 'src/app/Shared/Service/toast.service';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
  ],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  imageBaseUrl = 'https://localhost:44333/resources/';

  constructor(
    private cartService: CartService,
    private orderService: OrderService,
    private toast: ToastService
  ) {}

  selectedProdId: number = 0;
  selectedCartId: number = 0;
  quantity: number = -1;

  cartList$: Observable<Cart[]> = this.cartService.getCart();

  setId(prodId: number, cartId: number, quantity: number) {
    this.selectedProdId = prodId;
    this.selectedCartId = cartId;
    this.quantity = quantity;
  }

  placeOrder() {
    this.orderService
      .postOrder({
        productId: this.selectedProdId,
        quantity: this.quantity,
        CartId: this.selectedCartId,
      })
      .subscribe({
        next: (res) => {
          this.cartList$ = this.cartService.getCart();
          this.toast.successToast('Order made successfully!');
        },
        error: (err) => {
          this.toast.errorToast('Unexpected error, order did not execute');
        },
      });
  }

  deleteCart(id: number) {
    if (confirm('You are about to delete the product')) {
      this.cartService.deleteCartItem(id).subscribe({
        next: (res) => {
          this.cartList$ = this.cartService.getCart();
          this.toast.successToast('Product deleted successfully!');
        },
        error: (err) => {
          this.toast.errorToast('Unexpected error occured');
        },
      });
    }
  }
}
