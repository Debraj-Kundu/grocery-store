import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ProductService } from 'src/app/Shared/Service/product.service';
import { ActivatedRoute } from '@angular/router';
import { ToastService } from 'src/app/Shared/Service/toast.service';
import { Observable } from 'rxjs';
import { Product } from 'src/app/Shared/Interface/Product.interface';

const matModules = [
  MatFormFieldModule,
  MatCardModule,
  MatButtonModule,
  MatInputModule,
  MatDatepickerModule,
  MatNativeDateModule,
];
@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, ...matModules],
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],
})
export class AddProductComponent implements OnInit {
  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private toast: ToastService,
    private fb: FormBuilder
  ) {}

  id: string | null = '';
  product$!: Observable<Product>;
  productForm!: FormGroup;

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.product$ = this.productService.getProductById(this.id);

    this.productForm = this.fb.group({
      name: new FormControl('', { validators: [Validators.required] }),
      description: new FormControl('', { validators: [Validators.required] }),
      price: new FormControl('', { validators: [Validators.required] }),
      discount: new FormControl('', { validators: [Validators.required] }),
      categoryId: new FormControl('', { validators: [Validators.required] }),
      availableQuantity: new FormControl('', {
        validators: [Validators.required],
      }),
      image: new FormControl(''),//, { validators: [Validators.required] }
      specification: new FormControl(''),
      id: new FormControl(this.id),
    });
  }

  addProduct() {
    if (this.productForm.valid) {
      this.productService.postProduct(JSON.stringify(this.productForm.value)).subscribe();
    }
  }

  ClearForm() {
    this.productForm.reset();
  }
}
