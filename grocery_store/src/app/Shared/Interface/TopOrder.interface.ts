import { Product } from "./Product.interface";

export interface TopOrder{
    productId: number,
    product: Product,
    quantity: number
}