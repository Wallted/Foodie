import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  public products: Product[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.refreshData();
  }

  refreshData() {
    this.http.get<Product[]>(this.baseUrl + 'products/getall').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }

  control = new FormControl();
  formProduct: Product = new Product()

  ngOnInit() {
  }

  onSubmit() {
    this.http.post<Product[]>(this.baseUrl + 'products/add', this.formProduct).subscribe(result => {
      this.refreshData();
    }, error => console.error(error));
  }

  onDelete(id: number){
    console.log(id)
    this.http.delete<Product[]>(this.baseUrl + 'products/delete/'+ id.toString()).subscribe(result => {
      this.refreshData();
    }, error => console.error(error));
  }
}

