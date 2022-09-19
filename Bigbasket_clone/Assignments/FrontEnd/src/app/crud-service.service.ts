import { EnvironmentInjector, Injectable } from '@angular/core';
import { HttpClient, HttpParams,HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs';
import { Category } from './_model/category';
import { User } from './_model/user';
import { LoginComponent } from './main/Components/login/login.component';
import { LoginCred } from './main/Components/login/login-cred';
import { environment } from 'src/environments/environment';
import { LoggedIn } from './main/Components/login/loggedIn';
import { Router } from '@angular/router';
import { IProducts } from './_model/products';
@Injectable({
  providedIn: 'root'
})
export class CrudServiceService {

 private API_URL = environment.API_URL;
  private auth_token:string  = "";
  public Categories: Category[] = [];
  public searchedCategories : Category[] = [];
  public productsArray : IProducts[] = [];
  public userLoggedIn : boolean = false;
 
  // httpOptions = {
  //   headers: new HttpHeaders({
  //     'Content-Type': 'application/json',
  //     'Authorization': `Bearer ${this.auth_token}`
  // }) 
// };

  constructor(private http: HttpClient,private router: Router) { }

  getCategory() {
    return this.http.get<Category[]>(`https://localhost:44355/api/Category`).
    pipe(catchError(this.errorHandler));
  }



  addUser(user : User) : Observable<any>   {
    return this.http.post<any>(this.API_URL +"Account/Register",user).
    pipe(catchError(this.errorHandler));
  }

  login(logincred : LoginCred){ 
    return this.http.post<any>(this.API_URL+"Account/login",logincred)
    .pipe(catchError(this.errorHandler));
  }

  search(txt : string){
    return this.http.get<IProducts[]>(`https://localhost:44355/api/product/SearchProduct/${txt}`).pipe(catchError(this.errorHandler));;
  }
  searchCategory(txt : string){
    return this.http.get<Category[]>(`https://localhost:44355/api/category/searchCategory/${txt}`).pipe(catchError(this.errorHandler));;
  }
  // ERROR HANDLERRRRR 
  errorHandler(error: any) { 
    let errorMessage = "";

    
    if (error instanceof HttpErrorResponse) {
          if (error.error instanceof ErrorEvent) {
              console.error("Error Event");
          } else {
              console.log(`error status : ${error.status} ${error.statusText}`);
              errorMessage = error.error.message;             
          } 
      } else {
         errorMessage = `Message : ${error.message} \n Error Code : ${error.status}`
      }
      return throwError(()=> errorMessage);
    }
    
  }



