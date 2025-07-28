import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ProductService } from '../../core/services/product.service';
import { ProductViewModel } from '../../core/dataContracts/productViewModel';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatInputModule } from "@angular/material/input";


@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, RouterModule, MatButtonModule, MatIconModule, MatTableModule, MatPaginatorModule, MatSortModule, MatInputModule],
  providers: [ProductService],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductComponent implements OnInit {
  public displayedColumns: string[] = ['name', 'discountedPrice', 'stock', 'actions'];
  public dataSource = new MatTableDataSource<ProductViewModel>();
  constructor(private _productService: ProductService) { }

  public ngOnInit(): void {
    this.getProducts();
  }

  public getProducts(): void {
    this._productService.getAll().subscribe({
      next: (receivedProducts) => {
        this.dataSource.data = receivedProducts;
      },
      error: (err) => {
        console.error('Error fetching products:', err);
      }
    });
  }

  public deleteProduct(productId: number): void {
    this._productService.delete(productId).subscribe({
      next: () => {
        this.dataSource.data = this.dataSource.data.filter(product => product.id !== productId);
      },
      error: (err: any) => {
        console.error('Error deleting product:', err);
      }
    });
  }

  public applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}