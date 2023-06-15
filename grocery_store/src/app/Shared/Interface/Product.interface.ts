export interface Product{
    name: string,
    description: string,
    price: number,
    discount: number,
    categoryId: number,
    category: string,
    availableQuantity: number,
    image: File,
    specification: string,
    id: number,
    // createdOnDate: Date,
    // modifiedOnDate: Date,
}