
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { MatInput, MatInputModule } from '@angular/material/input';
import { RouterModule } from '@angular/router';
import { ProductService } from '../../../core/services/product.service';
import { CreateProductModel } from '../../../core/dataContracts/createProductModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-create',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
],
  templateUrl: './product-create.component.html',
  styleUrl: './product-create.component.scss'
})
export class ProductCreateComponent {
  productForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private router: Router
  )
  {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      description: [''],
      price: [0, [Validators.required, Validators.min(0)]],
      discountPercentage: [0, [Validators.required, Validators.min(0), Validators.max(100)]],
      stock: [0, [Validators.required, Validators.min(0)]]
    });
  }

  createProduct() {
    if (this.productForm.valid) {
      const product: CreateProductModel = this.productForm.value;
      this.productService.create(product).subscribe({
        next: (_) => {
          this.router.navigate(['/platform/products']);
        },
        error: (err) => {
          console.error('product creation failed:', err);
        }
      });
    }
  }
  
}
