
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CreateCustomerModel } from "../dataContracts/createCustomerModel";
import { Observable } from "rxjs";
import { CustomerViewModel } from "../dataContracts/customerViewModel";
import { UpdateCustomerModel } from "../dataContracts/updateCustomerModel";

@Injectable ({
    providedIn: 'root'
})
export class CustomerService {
private url: string = 'https://localhost:5016/api'

  constructor(private http: HttpClient) { }

  public getAll(): Observable<CustomerViewModel[]> {
    return this.http.get<CustomerViewModel[]>(`${this.url}/customer`);
  }

  public getById(id: number): Observable<CustomerViewModel> {
    return this.http.get<CustomerViewModel>(`${this.url}/customer/${id}`);
  }

  public create(customerToCreate: CreateCustomerModel): Observable<CustomerViewModel> {
    return this.http.post<CustomerViewModel>(`${this.url}/customer`, customerToCreate);
  }

  public update(customerToUpdate: UpdateCustomerModel): Observable<CustomerViewModel> {
    return this.http.put<CustomerViewModel>(`${this.url}/customer`, customerToUpdate);
  }

  public delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/product/${id}`);
  }
}