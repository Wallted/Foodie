import { Ingriedient } from "./ingiedient";

export interface Meal{
    id: number;
    name: string;
    date: Date;
    ingriedients: Ingriedient[];
    color: string;
}