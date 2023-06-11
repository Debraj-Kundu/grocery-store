import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartService } from 'src/app/Shared/Service/cart.service';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  constructor(private cartService: CartService) {}

  cartList$ = this.cartService.getCart();
}
