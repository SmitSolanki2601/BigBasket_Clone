import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IProducts } from '../_model/products';

@Injectable({
  providedIn: 'root'
})
export class ProductCrudService {

  // matchImage(post, image) {
  //   if (post.id === image.id) {
  //     return image.image
  //   } else {
  //     return '../../../assets/white.jpg'
  //   }
  // }

  // <img [src]="matchImage(post, image)">      //Html file

  private API_URL = environment.API_URL;
  public products : IProducts[] = [];
  public searchedProducts : IProducts[] = [];

  constructor(private http : HttpClient, private router: Router) { }

  public getProducts() {
      return this.http.get<IProducts[]>(this.API_URL+'product').
      pipe(catchError(this.errorHandler)); 
    }

    public searchProducts(txt: string) {
    return this.http.get<IProducts[]>(`https://localhost:44355/api/product/SearchProduct/${txt}`).pipe(catchError(this.errorHandler));;
    
    }
    

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
