import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from 'src/app/Shared/Service/product.service';
import { Product } from 'src/app/Shared/Interface/Product.interface';
import { Observable, map } from 'rxjs';

import { MatButtonModule } from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';

const matModules = [
  MatButtonModule,
  MatTableModule,
  MatPaginatorModule,
  MatIconModule,
  MatDialogModule,
];

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, ...matModules],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor(private productService: ProductService) {}

  productsList: Observable<Product[]> = this.productService.getAllProducts();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  displayColumns: string[] = ['name', 'description', 'price', 'image'];
  private dataSource = new MatTableDataSource<Product>();
  tableData$: Observable<any> = this.productsList.pipe(map(item => {
    const dataSource = this.dataSource;
    dataSource.data = item;
    return dataSource;
  }));

  loggedInAsAdmin:boolean = false;

  ngOnInit(): void {
    if(this.loggedInAsAdmin)
      this.displayColumns.push('actions');
    // this.tableData$ = this.productsList.pipe(map(item => {
    //   const dataSource = new MatTableDataSource<Product>();
    //   dataSource.data = item;
    //   return dataSource;
    // }))
    // this.productsList.subscribe(res=>{
    //   this.tableData = new MatTableDataSource<Product>(
    //     res
    //     );
    //     this.tableData.paginator = this.paginator;
    // })
  }
}
