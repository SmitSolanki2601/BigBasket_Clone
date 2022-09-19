import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginCred } from '../main/Components/login/login-cred';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public userLoggedIn = false;
  API_URL = environment.API_URL;

  constructor(private router: Router, private http: HttpClient) { }


  setToken(token: string): void {
    localStorage.setItem('token', token);
  }
  setUser(email: string): void {
    localStorage.setItem('user', email);
  }

  setRole(role: string): void {
    localStorage.setItem('role', role);
  }
  getToken(): string | null {
    return localStorage.getItem('token');
  }
  getUser(): string | null {
    return localStorage.getItem('user');
  }
  getRole(): string | null {
    return localStorage.getItem('role');
  }
  isLoggedIn() {
    if(this.getToken() == null) { return false; } 
    else return true;
  }

  logOut() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    localStorage.removeItem('role');
    this.userLoggedIn = false;
    this.router.navigate(['/']);
  }


  login(logincred: LoginCred) {
    return this.http.post<any>(this.API_URL + "Account/login", logincred)
      .pipe(catchError(this.errorHandler));
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
    return throwError(() => errorMessage);
  }

}
