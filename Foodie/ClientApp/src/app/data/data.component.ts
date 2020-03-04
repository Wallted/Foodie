import { Component, OnInit } from '@angular/core';
import { UserInfoService } from '../services/user-info.service';
import { UserInfo } from '../models/userinfo';

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.css']
})
export class DataComponent implements OnInit {

  constructor(private _userInfoService: UserInfoService) { }

  trainingFactors = [
    { value: 1.2, description: 'sedentary (little or no exercise)' },
    { value: 1.375, description: 'lightly active (light exercise/sports 1-3 days/week)' },
    { value: 1.55, description: 'moderately active (moderate exercise/sports 3-5 days/week)' },
    { value: 1.725, description: 'very active (hard exercise/sports 6-7 days a week)' },
    { value: 1.9, description: 'extra active (very hard exercise/sports & physical job or 2x training)' },
  ]
  userInfo: UserInfo;

  ngOnInit() {
    this._userInfoService.getUserInfo().subscribe(result=>this.userInfo=result)
  }

  updateUserInfo() {
    // console.log(this.userInfo.trainingFactor);
    this._userInfoService.updateUserInfo(this.userInfo).subscribe();
  }

  ngOnDestroy() {
    this._userInfoService.updateUserInfo(this.userInfo).subscribe();
  }

  isSelected(value: number){

  }
}
