import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-product',
  imports: [CommonModule, RouterModule, MatButtonModule, MatIconModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductComponent {
  public products = [
    { id: 1, name: 'Product 1', price: 100, category: { name: 'Some Category' }},
  ];

  public deleteProduct(productId: number): void {
    console.log(`Product with id ${productId} deleted`);
  }
}