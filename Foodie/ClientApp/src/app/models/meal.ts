import { Ingriedient } from "./ingiedient";

export interface Meal{
    name: string;
    date: Date;
    ingriedients: Ingriedient[];
    color: string;
}