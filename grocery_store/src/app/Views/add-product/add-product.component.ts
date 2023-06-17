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
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from 'src/app/Shared/Service/toast.service';
import { Observable } from 'rxjs';
import { Product } from 'src/app/Shared/Interface/Product.interface';
import { MatSelectModule } from '@angular/material/select';
import { CategoryService } from 'src/app/Shared/Service/category.service';
import { Category } from 'src/app/Shared/Interface/Category.interface';


const matModules = [
  MatFormFieldModule,
  MatCardModule,
  MatButtonModule,
  MatInputModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatSelectModule
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
    private router: Router,
    private toast: ToastService,
    private fb: FormBuilder,
    private categoryService:CategoryService
  ) {}

  id: string | null = '';
  product: Product = {
    name: '',
    description: '',
    price: 0,
    discount: 0,
    categoryId: 0,
    category: {name:'', id:0},
    availableQuantity: 0,
    productImage: '',
    imageFile: new File([], ''),
    specification: '',
    id: 0,
    reviews: []
    // createdOnDate: new Date(),
    // modifiedOnDate: new Date(),
  };

  imageFile!: File;
  productForm!: FormGroup;

  categoryList$ = this.categoryService.getAllCategories();

  selected!: any;

  ngOnInit(): void {
    this.productForm = this.fb.group({
      name: new FormControl('', { validators: [Validators.required] }),
      description: new FormControl('', { validators: [Validators.required] }),
      price: new FormControl('', { validators: [Validators.required] }),
      discount: new FormControl('', { validators: [Validators.required] }),
      categoryId: new FormControl('', { validators: [Validators.required] }),
      availableQuantity: new FormControl('', {
        validators: [Validators.required],
      }),
      image: new FormControl(''), //, { validators: [Validators.required] }
      specification: new FormControl(''),
      id: new FormControl(this.id),
    });
  }


  addProduct() {
    if (this.productForm.valid) {
      this.productForm.value.categoryId = this.selected.id;
      const formData: Product = Object.assign(this.productForm.value);
      formData.imageFile = this.imageFile;
      console.log(this.productForm.value);
      this.productService.postProduct(formData).subscribe({
        next: (res) => {
          this.toast.successToast('Product added successfully!');
          this.router.navigate(['/home']);
        },
        error: (res) => {
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
