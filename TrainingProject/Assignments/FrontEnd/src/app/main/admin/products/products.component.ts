import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CrudServiceService } from 'src/app/crud-service.service';
import { Category } from 'src/app/_model/category';
import { IProducts } from 'src/app/_model/products';
import { ProductCrudService } from 'src/app/_services/product-crud.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  users :any | undefined;
  name: string | undefined;
  address : string | undefined ;
  response!: { dbPath: ''; };
  searchForm: FormGroup;

  displaySearchedElements = false;


  constructor(private http : HttpClient, private router: Router, public prodService: ProductCrudService,
    public searchService : CrudServiceService, private fb : FormBuilder,private toastr : ToastrService) { 
    this.searchForm = this.fb.group({
      search: ['']
    });
  }

  ngOnInit(): void {
    this.prodService.getProducts().subscribe({
        next: (data) => {
          this.prodService.products = (data as IProducts[]);
          // console.log(this.Categories);
         }
    })
  
  }
  public createImgPath = (serverPath: string) => { 
    return `https://localhost:44355/api/${serverPath}`; 
  }

  onCreate = () => {
    this.users = {
      name: this.name,
      address: this.address,
      imgPath: this.response.dbPath
    }
  }

  uploadFinished = (event : any) => { 
    this.response = event; 
  }

  onSearch(): void {

    this.searchService.searchCategory(this.searchForm.value.search.toString()).subscribe({
      next: (res) => {
        console.log(res);
        this.searchService.Categories = res;
        this.displaySearchedElements = true;
    },
    error: (error) => {
      console.log(error);
    }
  })


}

}
