import { Injectable } from '@angular/core';
import { Product } from "../models/product.model";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Transaction } from '../models/transaction.model';

@Injectable({
  providedIn: 'root'
})
export class VendingServiceService {
  private readonly apiUrl = 'http://localhost:8080/api/vendingmachine/';
  private readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Referrer-Policy': '',
    })
  };
  constructor(private http: HttpClient) { }

  public getInventory(): Observable<Product[]> {
    console.log('getInventory');
    return this.http.get(this.apiUrl, this.httpOptions).pipe(
      map((response: any) => {
        return (response as any[]).map(item => item as Product);
      })
    );
  }

  public getInventoryProductById(id: number): Observable<Product> {
    console.log('getInventoryProductById', id);
    return this.http.get<Product>(this.apiUrl + 'product/' + id, this.httpOptions);
  }
  
  public getTransactions(): Observable<Transaction[]> {
    console.log('getTransactions');
    return this.http.get(this.apiUrl + 'transactions/', this.httpOptions).pipe(
      map((response: any) => {
        if (response) {
          return response.map((item: any) => {
            item.products = item.products.map((product: any) => product as Product);
            return item as Transaction;
          });
        } else {
          return [];
        }
      })
    );
  }
  

}
