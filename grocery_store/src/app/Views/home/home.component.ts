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
import { RouterModule } from '@angular/router';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { ToastService } from 'src/app/Shared/Service/toast.service';
import { CategoryService } from 'src/app/Shared/Service/category.service';

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
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    ...matModules,
  ],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit, OnDestroy {
  constructor(
    private productService: ProductService,
    private loginService: LoginService,
    private userStore: UserStoreService,
    private categoryService: CategoryService,
    private toast: ToastService,
    private fb: FormBuilder
  ) {}

  productsList$: Observable<Product[]> = this.productService.getAllProducts();
  categoryList$ = this.categoryService.getAllCategories();

  selected!: any;
  searchBox!: FormGroup;
  searchText = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  displayColumns: string[] = ['name', 'description', 'price', 'image'];
  private dataSource = new MatTableDataSource<Product>();

  tableData$: Observable<any> = this.productsList$.pipe(
    map((item) => {
      const dataSource = this.dataSource;
      dataSource.data = item;
      return dataSource;
    })
  );

  userRole: string = '';

  ngOnInit(): void {
    this.searchBox = this.fb.group({
      search: new FormControl(''),
    });
    const roleFormToken = this.loginService.getRoleFromToken();
    this.userStore.getRoleFormStore().subscribe((val) => {
      this.userRole = val || roleFormToken;
    });
    if (this.userRole === 'Admin') this.displayColumns.push('actions');
  }

  valueChange(value: any) {
    this.toast.successToast(value.name);
    this.tableData$ = this.productsList$.pipe(
      map((item) => {
        const dataSource = this.dataSource;
        dataSource.data = item.filter(
          (prod) => prod.categoryId === this.selected?.id
        );
        return dataSource;
      })
    );
  }
  filterByName() {
    this.tableData$ = this.productsList$.pipe(
      map((item) => {
        const dataSource = this.dataSource;
        dataSource.data = item.filter(
          (prod) =>
            prod.name
              .toLocaleLowerCase()
              .includes(this.searchBox.value.search.toLocaleLowerCase()) ||
            prod.description
              .toLocaleLowerCase()
              .includes(this.searchBox.value.search.toLocaleLowerCase())
        );
        return dataSource;
      })
    );
  }
  deleteProduct(id: string) {
    this.productService.deleteProduct(id).subscribe((res) => {
      this.tableData$ = this.productsList$.pipe(
        map((item) => {
          const dataSource = this.dataSource;
          dataSource.data = item;
          return dataSource;
        })
      );
    });
  }
  ngOnDestroy(): void {}
}