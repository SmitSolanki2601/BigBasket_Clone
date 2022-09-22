import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductCrudService } from 'src/app/_services/product-crud.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private router: Router, public productService : ProductCrudService) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe( {
        next: products => { 
          this.productService.products = products;
          console.log(this.productService.products);
        },
        error: err => console.log(err),
    })
  }

}
