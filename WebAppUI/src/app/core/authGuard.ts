import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, GuardResult, MaybeAsync, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { jwtDecode } from 'jwt-decode';

@Injectable({
    providedIn: 'root'
})




export class AuthGuard {

    constructor(private router: Router) {}

    canActivate(): boolean | UrlTree {
        const token = localStorage.getItem('token');

        if (token) {
            try {
                const decodedToken: any = jwtDecode(token);

                const currentTime = Math.floor(Date.now()/900);
                if (decodedToken.exp && decodedToken.exp < currentTime) {
                    localStorage.removeItem('token');
                    return this.router.createUrlTree(['/login']);
                }
                return true;
            } catch (e) {
                console.error('Invalid token!', e);
                return this.router.createUrlTree(['/login'], {
                    queryParams: { returnUrl: this.router.url }
                });
            }
        }

        return this.router.createUrlTree(['/login'], {
            queryParams: { returnUrl: this.router.url }
        });

    }

}




/*
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
*/