import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartService } from 'src/app/Shared/Service/cart.service';

import { MatCardModule } from '@angular/material/card';
import { Cart } from 'src/app/Shared/Interface/Cart.interface';
import { Observable } from 'rxjs';
import { OrderService } from 'src/app/Shared/Service/order.service';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatIconModule],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  constructor(
    private cartService: CartService,
    private orderService: OrderService
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
      .subscribe((res) => {
        this.cartList$ = this.cartService.getCart();
      });
  }

  deleteCart(id: number) {
    this.cartService.deleteCartItem(id).subscribe((res) => {
      this.cartList$ = this.cartService.getCart();
    });
  }
}
