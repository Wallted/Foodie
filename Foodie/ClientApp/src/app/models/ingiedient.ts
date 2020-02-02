import { Product } from "./product";

export class Ingriedient{
    id: number;
    quantity: number;
    product: Product;
    mealId: number;

    public getTotalCalories(){
        return 
    }

    public getTotalCarbohydrates(){
        return 
    }

    public getTotalFat(){
        return 
    }

    public getTotalProteins(){
        return this.quantity*this.product.protein;
    }
}