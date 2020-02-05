import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserInfo } from '../models/userinfo';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserInfoService {

  constructor(private _http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  getUserInfo(): Observable<UserInfo> {
    return this._http.get<UserInfo>(this.baseUrl + 'userinfo/get/');
  }

  updateUserInfo(userInfo: UserInfo): Observable<void> {
    return this._http.put<void>(this.baseUrl + 'userinfo/put/', userInfo);
  }
}
