import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DayData } from '../models/daydata';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DayDataService {

  constructor(private _http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  getDayData(day: Date): Observable<DayData> {
    return this._http.get<DayData>(this.baseUrl + 'daydata/get/' + day.toUTCString());
  }
  addDayData(dayData: DayData): Observable<number> {
    return this._http.post<number>(this.baseUrl + 'daydata/add/', dayData);
  }
}
