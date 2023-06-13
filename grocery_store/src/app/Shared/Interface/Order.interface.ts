import { Product } from "./Product.interface";
import { User } from "./User.interface";

export interface Order{
    customerId: string,
    customer: User,
    productId: string,
    product: Product,
    quantity: number,
    id: string,
    orderDate: Date,
    cartId:string
};