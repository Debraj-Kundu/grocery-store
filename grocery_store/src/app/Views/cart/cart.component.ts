import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartService } from 'src/app/Shared/Service/cart.service';

import { MatCardModule } from '@angular/material/card';
import { Cart } from 'src/app/Shared/Interface/Cart.interface';
import { Observable } from 'rxjs';
import { OrderService } from 'src/app/Shared/Service/order.service';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, MatCardModule],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  constructor(
    private cartService: CartService,
    private orderService: OrderService
  ) {}

  selectedProdId: string = '';
  selectedCartId: string = '';
  quantity: number = -1;

  cartList$: Observable<Cart[]> = this.cartService.getCart();

  setId(prodId: string, cartId: string, quantity: number) {
    this.selectedProdId = prodId;
    this.selectedCartId = cartId;
    this.quantity = quantity;
  }

  placeOrder() {
    this.orderService.postOrder({
      productId: this.selectedProdId,
      quantity: this.quantity,
      CartId: this.selectedCartId,
    }).subscribe();
  }
}
