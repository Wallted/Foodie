import { Component, OnInit, Inject } from '@angular/core';
import { Product } from '../models/product';
import { Ingriedient } from '../models/ingiedient';
import { MatDialogRef } from '@angular/material/dialog';
import { ProductsService } from '../services/products.service';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';

@Component({
  selector: 'app-ingriedient-dialog',
  templateUrl: './ingriedient-dialog.component.html',
  styleUrls: ['./ingriedient-dialog.component.css']
})
export class IngriedientDialogComponent implements OnInit {

  ingriedient: Ingriedient = new Ingriedient;
  products: Product[];
  options: string[];

  constructor(public dialogRef: MatDialogRef<IngriedientDialogComponent>, productsService: ProductsService, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    productsService.getAllProducts(http, baseUrl).subscribe((result) => {
      this.products = result;
      this.options = this.products.map(function (product) {
        return product.name
      });
      this.filteredOptions = this.myControl.valueChanges
        .pipe(
          startWith(''),
          map(value => this._filter(value))
        );
      this.myControl.valueChanges.subscribe((result) => {
        console.log(result)
        this.ingriedient.product = this.products.find(x => x.name == result);
      })
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  myControl = new FormControl();
  filteredOptions: Observable<string[]>;

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.options.filter(option => option.toLowerCase().includes(filterValue));
  }

  ngOnInit() { }
}