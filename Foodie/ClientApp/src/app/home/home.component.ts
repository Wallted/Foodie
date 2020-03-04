import { Component } from '@angular/core';
import { MealsService } from '../services/meals.service';
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
    if (progress > 100)
      return 'warn';
    else
      return 'primary';
  }

  warnComment(exceeding, unit) {
    if (exceeding > 0)
      return "Exceeded by " + exceeding + unit;
    else
      return "";
  }

  ngOnInit() {
  }
}