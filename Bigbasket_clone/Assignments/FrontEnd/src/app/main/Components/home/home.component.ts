import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CrudServiceService } from 'src/app/crud-service.service';
import { UsernameValidator } from '../../../../assets/validationFunction/Validators'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  id: number = 0;
  submitted: boolean = false;
  userform: FormGroup;
  loginError: string = "";


  constructor(
    private router: Router,private toastr : ToastrService,
    private fb: FormBuilder, private crud: CrudServiceService) {

    this.userform = this.fb.group({
      firstName: ['', [Validators.required, Validators.maxLength(10), UsernameValidator.cannotContainSpace]],
      lastName: ['', [Validators.required, Validators.maxLength(15), UsernameValidator.cannotContainSpace]],
      genderID: ['', [Validators.required, UsernameValidator.cannotContainSpace]],
      PhoneNumber: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10), UsernameValidator.cannotContainSpace]],
      email: ['', [Validators.required, Validators.maxLength(50), Validators.pattern('^[A-Za-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'), UsernameValidator.cannotContainSpace]],
      password: ['', [Validators.required, Validators.maxLength(50), UsernameValidator.cannotContainSpace]],
      // confirmPassword: ['', [Validators.required, Validators.maxLength(50)]],
    })
  }


  ngOnInit(): void {
  }

  reset() {
    this.userform.reset();
  }


  register() {
    console.log(this.userform.value);

    if (this.userform.invalid) // true if any form validation fail
      return


    if (this.id === 0) {
      // on Create New User
      this.crud.addUser(this.userform.value).subscribe({

        // console.log(this.userform.value);
        // next: (v) => {

        //   console.log(v);

        //   // this.userName = JSON.parse(JSON.stringify(v)).name;

        //   // this.isLoggedIn = true;

        // },

        error: (e) => {

          this.loginError = JSON.parse(JSON.stringify(e)).error?.errors;

          // this.loginValidation.Password = this.loginError?.Password?.toString();

          // this.loginValidation.Email = this.loginError?.Email?.toString();

          // this.loginValidation.Message = JSON.parse(JSON.stringify(e))?.error?.message;

        },

        complete: () => {
          this.toastr.success('User Registered');
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

  //  {
  //   this.crud.addUser(this.userform.value).subscribe( res => this.router.navigateByUrl('../') );
  // }
}

