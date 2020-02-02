import { Component, OnInit, Inject } from '@angular/core';
import { Meal } from '../models/meal';
import { Ingriedient } from '../models/ingiedient';
import { Product } from '../models/product';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IngriedientDialogComponent } from '../ingriedient-dialog/ingriedient-dialog.component';
import { MealsService } from '../services/meals.service';
import { MatExpansionPanel } from '@angular/material/expansion';

@Component({
  selector: 'app-meal-calendar',
  templateUrl: './meal-calendar.component.html',
  styleUrls: ['./meal-calendar.component.css']
})
export class MealCalendarComponent implements OnInit {
  public day: Date = new Date();
  public meals: Meal[] = new Array<Meal>();
  public fetchingData: boolean = true;

  displayedColumns: string[] = ['name', 'calories', 'quantity', 'protein', 'fat', 'carb', 'delete'];

  constructor(public dialog: MatDialog, public mealService: MealsService) {
    this.getData()
  }

  ngOnInit() {
  }
  onSwipeLeft(evt) {
    console.log("XDD")
  }
  getData() {
    this.actualStep = 0;
    this.fetchingData = true;
    this.mealService.getMealsFromDay(this.day).subscribe((result) => {
      this.meals = result;
      this.meals.forEach(element => {
        element.deleteForbid = false;
        var color = this.getRandomColor();
        element.panelColor = this.getPanelColor(color);
        element.tableColor = this.getTableColor(color);
      });
      this.fetchingData = false;
    })
  }

  changeDays(days: number) {
    this.day = new Date((this.day.getTime() + days * (1000 * 60 * 60 * 24)));
    this.getData();
  }

  addMeal() {
    var color = this.getRandomColor();
    var meal: Meal = { id: 0, name: "", date: this.day, ingriedients: new Array<Ingriedient>(), panelColor: this.getPanelColor(color), tableColor: this.getTableColor(color), deleteForbid: true };
    this.meals.push(meal)
    this.mealService.addMeal(meal).subscribe((result) => {
      meal.deleteForbid = false;
      meal.id = result;
    });
  }

  deleteMeal(mealId: number, exp: MatExpansionPanel) {
    exp.toggle();
    var mealIndex = this.meals.findIndex(m => m.id == mealId);
    this.meals.splice(mealIndex, 1);
    this.mealService.deleteMeal(mealId).subscribe((result) => {
    });
  }

  step: number = 36;
  actualStep: number = 0;
  getRandomColor(): number {
    var color = Math.floor(Math.random() * this.step) + this.actualStep;
    this.actualStep = (this.actualStep + this.step) % 360;
    return color;
  }


  getPanelColor(color: number) {
    return 'hsl(' + color + ', 100%, 80%)'
  }
  getTableColor(color: number) {
    return 'hsl(' + color + ', 100%, 90%)'
  }


  addIngriedient(meal: Meal) {
    const dialogRef = this.dialog.open(IngriedientDialogComponent, {
      width: '250px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (result.quantity && result.product) {
          meal.ingriedients.push(result);
          meal.ingriedients = [...meal.ingriedients]
          result.mealId = meal.id;
          this.mealService.addIngriedient(result).subscribe((resultID) => {
            result.id = resultID;
          })
        }
      }
    });
  }

  removeIngriedient(meal: Meal, ingriedientId: number) {
    var index = meal.ingriedients.findIndex(x => x.id == ingriedientId);
    meal.ingriedients.splice(index, 1);
    this.mealService.deleteIngriedient(ingriedientId).subscribe((result) => {
      // this.getData();
    })
  }
}