import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CrudServiceService } from 'src/app/crud-service.service';
import { Category } from 'src/app/_model/category';
import { ProductCrudService } from 'src/app/_services/product-crud.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  searchForm: FormGroup;
  loading: boolean = false;
  errorMessage:any ;
  displaySearchedElements = false;


  constructor(private http : HttpClient, private router: Router, public crudService: CrudServiceService,
    public searchService : CrudServiceService, private fb : FormBuilder,private toastr : ToastrService) { 
    this.searchForm = this.fb.group({
      search: ['']
    });
  }

  ngOnInit(): void {
    this.crudService.getCategory().subscribe({
        next: (data) => {
          this.crudService.Categories = (data as Category[]);
          // console.log(this.Categories);
         }
    })
    // ,this.toastr.show("Welcome to the category !!")
  
  }




  onSearch(): void {
    this.loading = true;
        this.errorMessage = "";
        if(this.searchForm.value.search.toString() == '') {
          this.loading = false;
        this.errorMessage =  "Please enter a search term";
        }
        else {
          this.searchService.searchCategory(this.searchForm.value.search.toString()).subscribe({
            next: (res) => {
              
              console.log(res);
              this.searchService.Categories = res;
              this.displaySearchedElements = true;
          },
          error: (error) => {
            this.errorMessage = error;
            this.loading = false;
      
            throw error;
          },
          complete: () => {
            console.log(this.searchService.searchedCategories);
            this.loading = false;
           }
        })
      
        } 
}
  }



