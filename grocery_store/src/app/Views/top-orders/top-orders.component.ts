import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopOrderService } from 'src/app/Shared/Service/topOrder.service';

@Component({
  selector: 'app-top-orders',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './top-orders.component.html',
  styleUrls: ['./top-orders.component.css'],
})
export class TopOrdersComponent {
  constructor(private topOrderService: TopOrderService) {}

  topOrders$ = this.topOrderService.getTopOrderedProducts();

  getByDate(){//get from a dropdown
    this.topOrders$ = this.topOrderService.getTopOrderedProducts(5, 5, 0);
  }
}
