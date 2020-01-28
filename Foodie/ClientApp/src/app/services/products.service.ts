import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor() { }

  getAllProducts(http: HttpClient, baseUrl: string) : Observable<Product[]> {
    return http.get<Product[]>(baseUrl + 'products/getall');
  }
}
