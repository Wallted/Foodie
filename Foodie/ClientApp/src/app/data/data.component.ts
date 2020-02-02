import { Component, OnInit } from '@angular/core';
import { DayDataService } from '../services/day-data.service';
import { DayData } from '../models/daydata';

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.css']
})
export class DataComponent implements OnInit {

  constructor(private _dayDataService: DayDataService) { }

  dayData: DayData ={id: 0, date: new Date, age: 23, weight: 85, height:182, trainingFactor: 1.5, isMan: true }
  ngOnInit() {
    // this._dayDataService.getDayData(new Date()).subscribe(result=>{
    //   this.dayData=result;
    // })
  }

  addDayData(){
    this._dayDataService.addDayData(this.dayData).subscribe(result=>{
      this.dayData.id=result;
    })
  }
}
