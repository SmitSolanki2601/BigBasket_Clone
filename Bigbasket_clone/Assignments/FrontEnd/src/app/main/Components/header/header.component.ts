import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CrudServiceService } from 'src/app/crud-service.service';
import { Category } from 'src/app/_model/category';
import { AuthService } from 'src/app/_services/auth.service';
import { ProductCrudService } from 'src/app/_services/product-crud.service';
import { UsernameValidator } from '../../../../assets/validationFunction/Validators'

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  id: number = 0;
  submitted: boolean = false;
  userform: FormGroup;
  searchForm: FormGroup;
  loginError: string = "";
  subCategories: Category[] = [];


  selectedCategory: any = {
    id: 0, name: ''
  };



  constructor(
    private router: Router, private toastr: ToastrService,
    private fb: FormBuilder, public crud: CrudServiceService, public loginService: AuthService, public productService: ProductCrudService) {

    this.userform = this.fb.group({
      firstName: ['', [Validators.required, Validators.maxLength(10), UsernameValidator.cannotContainSpace]],
      lastName: ['', [Validators.required, Validators.maxLength(15), UsernameValidator.cannotContainSpace]],
      genderID: ['', [Validators.required, UsernameValidator.cannotContainSpace]],
      PhoneNumber: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10), UsernameValidator.cannotContainSpace]],
      email: ['', [Validators.required, Validators.maxLength(50), Validators.pattern('^[A-Za-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'), UsernameValidator.cannotContainSpace]],
      password: ['', [Validators.required, Validators.maxLength(50), UsernameValidator.cannotContainSpace]],
      // confirmPassword: ['', [Validators.required, Validators.maxLength(50)]],
    }),
      this.searchForm = this.fb.group({
        search: ['']
      });
  }


  ngOnInit(): void {
    this.crud.getCategory().subscribe({
      next: (categories) => {
        this.crud.Categories = categories;
      },
      error: (err) => { console.log(err); },
      complete: () => { }
    }),

      this.onSelect(this.selectedCategory.id);
  }


  onSelect(categoryId: number) {
    console.log(this.crud.Categories);
    this.subCategories = this.crud.Categories.filter(x => x.parentId == categoryId)
    console.log(categoryId)
    console.log(this.subCategories)
    //  getCategory().filter((item) => item.countryid == countryid);
  }

  reset() {
    this.userform.reset();
  }

  onSearch() {
    this.productService.searchProducts(this.searchForm.value.search.toString()).subscribe({
      next: products => {
        this.productService.products = products;
        console.log(this.productService.products);
      },
      error: err => this.toastr.error(err),
      complete: () => console.log('Completed')
    })
  }
  register() {
    console.log(this.userform.value);

    if (this.userform.invalid) // true if any form validation fail
      return


    if (this.id === 0) {
      // on Create New User
      this.crud.addUser(this.userform.value).subscribe({
        error: (e) => {

          this.loginError = JSON.parse(JSON.stringify(e)).error?.errors;
        },

        complete: () => {
          this.toastr.success('User Registered')
          this.router.navigate(['/login']);

        }
        // if (res.success) {
        //   this.userform.value }

        //   else {
        //     res.error = res.error;
        //     console.log(res.error);
        //   }
        // console.log(res.success);
      });
    }


    //Redirecting to user List page after save or update
    // this.router.navigate(['/login']);
  }

  logout() {
    this.loginService.logOut();
  }
}

