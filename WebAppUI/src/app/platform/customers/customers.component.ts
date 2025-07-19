
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { CustomerViewModel } from '../../core/dataContracts/customerViewModel';
import { CustomerService } from '../../core/services/customer.service';

@Component({
  selector: 'app-customers',
  imports: [RouterModule, MatButtonModule, MatIconModule],
  providers: [CustomerService],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.scss'
})
export class CustomersComponent implements OnInit {
  public customers: CustomerViewModel[] = [];

  constructor(private _customerService: CustomerService) { }
  public ngOnInit(): void {
    this.getCustomers();
  }

  public getCustomers(): void {
    this._customerService.getAll().subscribe({
      next: (receivedCustomers) => {
        this.customers = receivedCustomers;
      },
      error: (err) => {
        console.error('Error fetching Customers', err);
      }
    });
  }

  public deleteCustomer(customerId: number): void {
    this._customerService.delete(customerId). subscribe({
      next: () => {
        this.customers = this.customers.filter(customer => customer.id !== customerId);
      },
      error: (err: any) => {
        console.error('Error deleting customer')
      }
    });
  }

  


}