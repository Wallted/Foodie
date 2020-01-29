import { Injectable, Inject, LOCALE_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Meal } from '../models/meal';
import { DatePipe } from '@angular/common';
import { debug } from 'util';
import { Ingriedient } from '../models/ingiedient';

@Injectable({
  providedIn: 'root'
})
export class MealsService {
  _baseUrl: string;

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string, @Inject('LOCALE_ID') private localeId: string) {
    this._baseUrl = baseUrl;
  }

  getMealsFromDay(day: Date): Observable<Meal[]> {
    return this._http.get<Meal[]>(this._baseUrl + 'meals/get/' + day.toUTCString());
  }

  addMeal(meal: Meal): Observable<number> {
    meal.date=new Date(meal.date.toUTCString());
    return this._http.post<number>(this._baseUrl + 'meals/add', meal);
  }

  addIngriedient(ingriedient: Ingriedient): Observable<number> {
    return this._http.post<number>(this._baseUrl + 'ingriedients/add', ingriedient);
  }
}
