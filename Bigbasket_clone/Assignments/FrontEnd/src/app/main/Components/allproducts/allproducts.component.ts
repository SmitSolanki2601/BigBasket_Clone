import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductCrudService } from 'src/app/_services/product-crud.service';

@Component({
  selector: 'app-allproducts',
  templateUrl: './allproducts.component.html',
  styleUrls: ['./allproducts.component.css']
})
export class AllproductsComponent implements OnInit {

  constructor(private router: Router, public productService : ProductCrudService,private toastr : ToastrService)  { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe( {
        next: products => { 
          this.productService.products = products;
          console.log(this.productService.products);
        },
        error: err => this.toastr.error(err)
    })
  }



}
