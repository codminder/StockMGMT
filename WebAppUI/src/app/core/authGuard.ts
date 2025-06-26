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
        if(token) {
            const decodedToken = jwtDecode(token);
            return true;
        } else {
            return this.router.createUrlTree(['/login']);
        }
    }
}