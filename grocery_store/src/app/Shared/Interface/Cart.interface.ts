import { Product } from "./Product.interface";
import { User } from "./User.interface";

export interface Cart{
    customerId: string,
    customer: User,
    productId: string,
    product: Product,
    quantity: number,
    id: number,
};