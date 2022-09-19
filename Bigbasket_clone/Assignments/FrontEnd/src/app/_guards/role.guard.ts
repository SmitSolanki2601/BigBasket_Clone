import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../_services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {

  constructor(private auth : AuthService, private router: Router) {}


  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot) {

    if(this.auth.getRole()=='admin' || this.auth.getRole()=='Admin')
    return true;
    
    else {
      alert("You Must Have  Admin Account !")
      this.router.navigate(['/login']);
      return false;
    }
  }
  
}
