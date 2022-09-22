import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CrudServiceService } from 'src/app/crud-service.service';

@Component({
  selector: 'app-searchedproduct',
  templateUrl: './searchedproduct.component.html',
  styleUrls: ['./searchedproduct.component.css']
})
export class SearchedproductComponent implements OnInit {

  searchForm: FormGroup;

  constructor(private fb: FormBuilder, public searchService: CrudServiceService) {
    this.searchForm = this.fb.group({
      search: ['']
    });
  }

  ngOnInit(): void {
    
  }

  onSearch(): void {

    this.searchService.search(this.searchForm.value.search).subscribe({
      next: (res) => {
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
