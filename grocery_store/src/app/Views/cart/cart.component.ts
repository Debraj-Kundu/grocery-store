import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartService } from 'src/app/Shared/Service/cart.service';

import {MatCardModule} from '@angular/material/card';
import { Cart } from 'src/app/Shared/Interface/Cart.interface';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, MatCardModule],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  constructor(private cartService: CartService) {}

  cartList$:Observable<Cart[]> = this.cartService.getCart();
}
