export interface Product{
    name: string,
    description: string,
    price: number,
    discount: number,
    categoryId: number,
    category: string,
    availableQuantity: number,
    image: string,
    specification: string,
    id: number,
    createdOnDate: Date,
    modifiedOnDate: Date,
    entityState: string
}