import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup,FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { CrudServiceService } from 'src/app/crud-service.service';
import { Category } from 'src/app/_model/category';

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css']
})
export class AddEditComponent implements OnInit {

  searchForm: FormGroup;



  constructor(private http : HttpClient, private router: Router, public crudService: CrudServiceService,public searchService : CrudServiceService, private fb : FormBuilder) { 
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
  
  }




  onSearch(): void {

    this.searchService.search(this.searchForm.value.search.toString()).subscribe({
      next: (res) => {
        console.log(res);
        this.searchService.productsArray = res;
    },
    error: (error) => {
      console.log(error);
    },
    complete: () => {
      console.log(this.searchService.productsArray);
   
     }
  })


}

}
