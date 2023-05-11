import { Product } from "./product.model";

export interface Transaction {
    id: number;
    products: Product[];
    amountPaid: number;
}
