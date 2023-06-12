import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from 'src/app/Shared/Service/product.service';
import { Product } from 'src/app/Shared/Interface/Product.interface';
import { Observable, map } from 'rxjs';

import { MatButtonModule } from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { LoginService } from 'src/app/Shared/Service/login.service';
import { UserStoreService } from 'src/app/Shared/Service/user-store.service';

const matModules = [
  MatButtonModule,
  MatTableModule,
  MatPaginatorModule,
  MatIconModule,
  MatDialogModule,
  MatSelectModule,
  MatFormFieldModule,
];

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, ...matModules],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit, OnDestroy {
  constructor(
    private productService: ProductService,
    private loginService: LoginService,
    private userStore: UserStoreService
  ) {}
  

  productsList: Observable<Product[]> = this.productService.getAllProducts();
  categoryList: string[] = ['Biscuit', 'Juice', 'Chips', 'Candy', 'Chocolate'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  displayColumns: string[] = ['name', 'description', 'price', 'image'];
  private dataSource = new MatTableDataSource<Product>();
  tableData$: Observable<any> = this.productsList.pipe(
    map((item) => {
      const dataSource = this.dataSource;
      dataSource.data = item;
      return dataSource;
    })
  );

  userRole: string = '';

  ngOnInit(): void {
    const roleFormToken = this.loginService.getRoleFromToken();
    this.userStore.getRoleFormStore().subscribe((val) => {
      this.userRole = val || roleFormToken;
    });
    if (this.userRole === 'Admin') this.displayColumns.push('actions');
  }

  ngOnDestroy(): void {
    
  }
}
