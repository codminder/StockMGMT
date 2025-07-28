import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { CustomerViewModel } from '../../core/dataContracts/customerViewModel';
import { CustomerService } from '../../core/services/customer.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule
  ],
  providers: [CustomerService],
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {
  public dataSource = new MatTableDataSource<CustomerViewModel>();
  public displayedColumns: string[] = [
    'firstName',
    'lastName',
    'street',
    'postalCode',
    'appartmentNumber',
    'actions'
  ];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _customerService: CustomerService) {}

  ngOnInit(): void {
    this.getCustomers();
  }

  public getCustomers(): void {
    this._customerService.getAll().subscribe({
      next: (receivedCustomers) => {
        this.dataSource.data = receivedCustomers;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (err) => {
        console.error('Error fetching customers:', err);
      }
    });
  }

  public deleteCustomer(customerId: number): void {
    this._customerService.delete(customerId).subscribe({
      next: () => {
        this.dataSource.data = this.dataSource.data.filter(
          (customer) => customer.id !== customerId
        );
      },
      error: (err: any) => {
        console.error('Error deleting customer:', err);
      }
    });
  }

  public applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLocaleLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}