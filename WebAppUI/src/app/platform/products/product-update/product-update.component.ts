import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput, MatInputModule } from '@angular/material/input';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ProductService } from '../../../core/services/product.service';
import { UpdateProductModel } from '../../../core/dataContracts/updateProductModel';

@Component({
  selector: 'app-product-update',
  imports: [CommonModule, ReactiveFormsModule, FormsModule, RouterModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  providers: [ProductService],
  templateUrl: './product-update.component.html',
  styleUrl: './product-update.component.scss'
})
export class ProductUpdateComponent {
  public productForm: FormGroup | undefined;
  private productId!: number;


  constructor (
    private fb: FormBuilder,
    private productService: ProductService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
        if (id) {
        const numericId = Number(id);
        this.productId = numericId;
        
        this.productService.getById(numericId).subscribe(product => {
          this.productForm = this.fb.group({
            name: [product.name, Validators.required],
            description: [product.description],
            price: [product.price, [Validators.required, Validators.min(0)]],
            discountPercentage: [product.discountPercentage, [Validators.required, Validators.min(0), Validators.max(100)]],
            stock: [product.stock, [Validators.required, Validators.min(0)]]
          });
        });
      }
    });
  }

  updateProduct() {
    if(this.productForm!.valid) {
      const product: UpdateProductModel = this.productForm!.value;
      product.id = this.productId;
      this.productService.update(product).subscribe({
        next: (_) => {
          this.router.navigate(['/platform/products']);
        },
        error:(err) => {
          console.error('Poduct update failed:', err);
        }
      });
    }
  }
}