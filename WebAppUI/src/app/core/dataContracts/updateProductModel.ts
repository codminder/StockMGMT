export interface UpdateProductModel {
    id: number;
    name: string;
    description: string;
    price: number;
    stock: number;
    discountPercentage?: number;
    discountedPrice: number;
}