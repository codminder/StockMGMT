import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateProductModel } from './dataContracts/createProductModel';
import { Observable } from 'rxjs';
import { ProductViewModel } from './dataContracts/productViewModel';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  public create(productToCreate: CreateProductModel): Observable<ProductViewModel> {
    return this.http.post<ProductViewModel>(`$(this.url)/products`, productToCreate);
  }

  public getAll(): Observable<ProductViewModel[]>{
    return this.http.get<ProductViewModel[]>(`$this.url/product`);
  }
}
