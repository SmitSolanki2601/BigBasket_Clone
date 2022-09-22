import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MessageService } from 'primeng/api';
import { throwError } from 'rxjs';
import { CrudServiceService } from 'src/app/crud-service.service';
import { AuthService } from 'src/app/_services/auth.service';
import { UsernameValidator } from 'src/assets/validationFunction/Validators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginform: FormGroup;
  resp: any;

  constructor(private loginservice: AuthService, private fb: FormBuilder, private router: Router, private toastr: ToastrService) {
    this.loginform = this.fb.group({
      email: ['', [Validators.required, Validators.maxLength(50), Validators.pattern('^[A-Za-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'), UsernameValidator.cannotContainSpace]],
      password: ['', [Validators.required, Validators.maxLength(12), UsernameValidator.cannotContainSpace]],
    });
  }

  ngOnInit(): void {
    // if(this.loginservice.isLoggedIn()) {
    //   this.router.navigate(['/admin']);
    // }
  }

  reset() {
    this.loginform.reset();
  }
  login() {
    this.loginservice.login(this.loginform.value).subscribe({
      next: (res) => {
        this.loginservice.setToken(res.token);
        this.loginservice.setUser(res.email);
        this.loginservice.setRole(res.role);
        
        // this.loginservice.userLoggedIn = true;

        if (res.role == "User" || res.role == "user") {
          this.router.navigate(['/dashboard']);
        }
        else if(res.role == "Admin" || res.role == "admin"){
          this.router.navigate(['/admin']);
        }
        // else {
        //   this.router.navigate(['/dashboard']);
        // }


      },
      //console.log( res.email , res.token );

      error: (error) => {

        this.toastr.error(error);


        // error => this.toastr.error(error.messageType, `We have an error: ${error}`)
        //   if (error instanceof HttpErrorResponse) {
        //     if (error.error instanceof ErrorEvent) {
        //         console.error("Error Event");
        //     } else {
        //         console.log(`error status : ${error.status} ${error.statusText}`);
        //         switch (error.status) {
        //             case 400:      //login
        //                 this.router.navigateByUrl("");
        //                 break;
        //             case 403:     //forbidden
        //                 this.router.navigateByUrl("/login");
        //                 break;
        //         }
        //     } 

        // } else {

        //     console.error("some thing else happened");
        // }
        // return throwError(() => error);
      },
      complete: () => {

        this.loginservice.userLoggedIn = true;
    
        this.toastr.success("User Logged in Successfully!");
      }
    });
  }
}

