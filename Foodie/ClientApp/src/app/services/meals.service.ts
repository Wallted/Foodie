import { Injectable, Inject, LOCALE_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Meal } from '../models/meal';
import { DatePipe } from '@angular/common';
import { debug } from 'util';

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

  addMeal(meal: Meal): Observable<Meal> {
    meal.date=new Date(meal.date.toUTCString());
    return this._http.post<Meal>(this._baseUrl + 'meals/add', meal);
  }
}
