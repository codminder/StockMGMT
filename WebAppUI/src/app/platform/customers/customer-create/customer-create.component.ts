
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RouterModule, Router } from '@angular/router';
import { CustomerService } from '../../../core/services/customer.service';
import { CreateCustomerModel } from '../../../core/dataContracts/createCustomerModel';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-customer-create',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
],
  templateUrl: './customer-create.component.html',
  styleUrls: ['./customer-create.component.scss']
})
export class CustomerCreateComponent {
  customerForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private customerService: CustomerService,
    private router: Router
  )
  {
    this.customerForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      street: ['', Validators.required],
      postalCode: ['', Validators.required],
      appartmentNumber: ['', Validators.required],
    });
  }

  createCustomer() {
    if (this.customerForm.valid) {
      const customer: CreateCustomerModel = this.customerForm.value;
      this.customerService.create(customer).subscribe({
        next: (_) => {
          this.router.navigate(['/platform/customers']);
        },
        error: (err) => {
          console.error('Customer creation failed:', err);
        }
      });
    }
  }

}
