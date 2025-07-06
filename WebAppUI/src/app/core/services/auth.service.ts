import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LoginDto } from "../dataContracts/loginDto";
import { RegisterDto } from "../dataContracts/registerDto";


interface LoginResponse {
    token: string;
}

@Injectable({
    providedIn: 'root',
})

export class AuthService {
    private url: string = "http://localhost:5016/api";
    constructor(private http: HttpClient) { }

    public login(loginDto: LoginDto): Observable<string> {
        return this.http.post<string>(`${this.url}/auth/login`, loginDto,);
    }

    public register(registerDto: RegisterDto): Observable<string> {
        return this.http.post<string>(`${this.url}/auth/register`, registerDto);
    }
}