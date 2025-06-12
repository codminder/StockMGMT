/*
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CreateCustomerModel } from "../dataContracts/createCustomerModel";
import { Observable } from "rxjs";

@Injectable ({
    providedIn: 'root'
})
export class CustomerService {
private url: string = 'https://localhost:1234/api'

  constructor(private http: HttpClient) { }

  public create(productToCreate: CreateCustomerModel): Observable<CustomerViewModel> {
    return this.http.customerViewModel>(`${this.url}/customers`, customerToCreate);
  }

  public getAll(): Observable<CustomerViewModel[]>{
    return this.http.get<CustomerViewModel[]>(`${this.url}/customer`);
  }
}

*/