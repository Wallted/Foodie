import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-product-dialog',
  templateUrl: './product-dialog.component.html',
  styleUrls: ['./product-dialog.component.css']
})
export class ProductDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ProductDialogComponent>) { }

  product: Product;
  
  ngOnInit() {
    this.product = new Product();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
