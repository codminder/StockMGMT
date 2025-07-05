export interface ProductViewModel {
    id: number;
    name: string;
    description: string;
    price: number;
    stock: number;
    discountPercentage?: number;
    calculateDiscounted: number;
}