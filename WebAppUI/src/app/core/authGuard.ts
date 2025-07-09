import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, GuardResult, MaybeAsync, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { jwtDecode } from 'jwt-decode';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router) {}

  canActivate(): boolean | UrlTree {
    const token = localStorage.getItem('token');
    if (token) {
      const decodedToken = jwtDecode(token);
      const currentTime = Math.floor(Date.now() / 1000);

      if (decodedToken.exp && decodedToken.exp < currentTime) {
        
        localStorage.removeItem('token');
        // Token is verlopen, dus doorverwijzen naar login pagina
        return this.router.createUrlTree(['/login']);
      }
      console.log(decodedToken);
      return true;
    } else {
      // Geen token, dus doorverwijzen naar login pagina
      return this.router.createUrlTree(['/login']);
    }
  }
}

