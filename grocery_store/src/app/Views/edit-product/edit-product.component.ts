import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/Shared/Service/product.service';
import { Observable, map, tap } from 'rxjs';
import { Product } from 'src/app/Shared/Interface/Product.interface';
import { ToastService } from 'src/app/Shared/Service/toast.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { CategoryService } from 'src/app/Shared/Service/category.service';
import { MatSelectModule } from '@angular/material/select';
import { Category } from 'src/app/Shared/Interface/Category.interface';

const matModules = [
  MatFormFieldModule,
  MatCardModule,
  MatButtonModule,
  MatInputModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatSelectModule,
];

@Component({
  selector: 'app-edit-product',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, ...matModules],
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css'],
})
export class EditProductComponent implements OnInit {
  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private toast: ToastService,
    private fb: FormBuilder,
    private categoryService: CategoryService
  ) {
    this.productForm = this.fb.group({
      name: new FormControl('', { validators: [Validators.required] }),
      description: new FormControl('', { validators: [Validators.required] }),
      price: new FormControl('', { validators: [Validators.required] }),
      discount: new FormControl('', { validators: [Validators.required] }),
      categoryId: new FormControl('', { validators: [Validators.required] }),
      availableQuantity: new FormControl('', {
        validators: [Validators.required],
      }),
      imageFile: new FormControl(''), //, { validators: [Validators.required] }
      productImage: new FormControl(''),
      specification: new FormControl(''),
      id: new FormControl(this.id),
    });
  }

  id: string = '';
  product$!: Observable<Product>;
  productForm!: FormGroup;

  categoryList$ = this.categoryService.getAllCategories();

  selected!: any;
  imageFile!: File;

  ngOnInit(): void {
    this.LoadFormData();
  }

  LoadFormData() {
    this.id = this.route.snapshot.paramMap.get('id') ?? '';
    this.product$ = this.productService.getProductById(this.id).pipe(
      tap((prod) => {
        this.productForm.patchValue(prod);
        this.selected = prod.categoryId;
      })
    );
  }

  editProduct() {
    if (this.productForm.valid) {
      this.productForm.value.categoryId = this.selected;
      const formData: Product = Object.assign(this.productForm.value);
      console.log(formData);
      if (this.imageFile != undefined) formData.imageFile = this.imageFile;
      console.log(formData);
      this.productService.updateProduct(this.id, formData).subscribe({
        next: (res) => {
          this.toast.successToast('Product updated successfully!');
        },
        error: (err) => {
          console.log(err);
          this.toast.errorToast('Error occured retry!');
        },
      });
    }
  }

  onChange(event: any) {
    this.imageFile = event.target.files[0];
    console.log(event.target.files[0]);
  }

  clearForm() {
    this.productForm.reset();
  }
}
