import { Category } from "./Category.interface";

export interface Product{
    name: string,
    description: string,
    price: number,
    discount: number,
    categoryId: number,
    category: Category,
    availableQuantity: number,
    productImage: string,
    imageFile: File,
    specification: string,
    id: number,
    reviews: []
}