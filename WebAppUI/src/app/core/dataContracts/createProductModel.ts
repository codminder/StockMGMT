export interface CreateProductModel {
    name: string;
    description: string;
    price: number;
    stock: number;
    discountPercentage?: number;
  }