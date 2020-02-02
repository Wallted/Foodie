import { Injectable, Inject, LOCALE_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Meal } from '../models/meal';
import { DatePipe } from '@angular/common';
import { debug } from 'util';
import { Ingriedient } from '../models/ingiedient';
import { Macro } from '../models/Macro';

@Injectable({
  providedIn: 'root'
})
export class MealsService {
  _baseUrl: string;

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  getMealsFromDay(day: Date): Observable<Meal[]> {
    return this._http.get<Meal[]>(this._baseUrl + 'meals/get/' + day.toUTCString());
  }

  addMeal(meal: Meal): Observable<number> {
    meal.date = new Date(meal.date.toUTCString());
    return this._http.post<number>(this._baseUrl + 'meals/add', meal);
  }

  deleteMeal(mealId: number): Observable<any> {
    return this._http.delete<any>(this._baseUrl + 'meals/delete/' + mealId);
  }

  addIngriedient(ingriedient: Ingriedient): Observable<number> {
    return this._http.post<number>(this._baseUrl + 'ingriedients/add', ingriedient);
  }
  deleteIngriedient(ingriedientId: number): Observable<any> {
    return this._http.delete<any>(this._baseUrl + 'ingriedients/delete/' + ingriedientId);
  }

  getMacro(day: Date): Observable<Macro> {
    return this._http.get<Macro>(this._baseUrl + 'meals/macro/' + day.toUTCString());
  }
}
