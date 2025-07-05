import { Injectable } from "@angular/core";
import { jwtDecode } from "jwt-decode";
import { Router } from '@angular/router';
import { User } from '../dataContracts/userModel';


@Injectable({
    providedIn: 'root',
})


export class UserService {
    constructor(private router: Router) { }

    public getUser(): User {
        const token = localStorage.getItem('token');
    

        if (token) {
            const user = jwtDecode(token);
            return user as User;
        }
        this.router.navigate(['/login']);
        return {} as User;
    }

    public getTokenTimeValid(): number {
        const token = localStorage.getItem('token');
        if (token) {
            const decodedToken: any = jwtDecode(token);
            return decodedToken.exp ? decodedToken.exp - Math.floor(Date.now()/1000) : 0;
        }
        return 0;
    }

}