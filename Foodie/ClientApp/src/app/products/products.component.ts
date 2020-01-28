import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  public products: Product[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'products/getall').subscribe(result => {
      this.products = result;
      console.log(baseUrl);
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}

