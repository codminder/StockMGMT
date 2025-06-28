import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { materialize } from 'rxjs';
import { ProductComponent } from '../products.component';
import { ProductService } from '../../../core/services/product.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-view',
  imports: [CommonModule, MatListModule, MatProgressSpinner],
  templateUrl: './product-view.component.html',
  styleUrl: './product-view.component.scss'
})
export class ProductViewComponent {
  public product?: ProductViewModel;

  constructor(
    privae route: ActivatedRoute,
    private productService: ProductService
  ) {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        const numericId =Number(id);
        this.productService.getById(numericId).subscribe(product => {
          this.product = product;
        });
      }
    });
  }
}
