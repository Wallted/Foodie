import { Component } from '@angular/core';
import { MealsService } from '../services/meals.service';
import { DayDataService } from '../services/day-data.service';
import { Ingriedient } from '../models/ingiedient';
import { Macro } from '../models/macro';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  macro: Macro;
  computed: boolean;

  constructor(private _mealService: MealsService) {
    this.computed = false;
    this._mealService.getMacro(new Date()).subscribe(result => {
      console.log(result);
      this.macro = result;
      this.computed = true;
    });
  }

  updateColor(progress) {
      return 'primary';
  }

  ngOnInit() {
  }
}