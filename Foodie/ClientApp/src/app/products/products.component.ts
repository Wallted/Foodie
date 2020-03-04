import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ProductDialogComponent } from '../product-dialog/product-dialog.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  public products: Product[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, public dialog: MatDialog) {
  }

  displayedColumns: string[] = ['name', 'calories', 'carbs', 'fat', 'protein', 'delete'];

  refreshData() {
    this.http.get<Product[]>(this.baseUrl + 'products/getall').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }

  ngOnInit() {
    this.refreshData();
  }

  addProduct() {
    const dialogRef = this.dialog.open(ProductDialogComponent, {
      width: '250px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (result.name && result.calories && result.carbs && result.fat && result.protein) {
          this.products.push(result);
          this.products = [...this.products];
          this.http.post<Product[]>(this.baseUrl + 'products/add', result).subscribe(resultId => {
            result.id = resultId;
          }, error => console.error(error));
        }
      }
    });
  }

  onDelete(id: number, button) {
    button.disabled = true;
    var prodcutIndex = this.products.findIndex(x => x.id == id);
    this.products.splice(prodcutIndex, 1);
    this.products = [...this.products];

    this.http.delete<Product[]>(this.baseUrl + 'products/delete/' + id.toString()).subscribe(result => {
    }, error => {
      console.error(error);
      button.disabled = false;
    }
    );
  }
}

