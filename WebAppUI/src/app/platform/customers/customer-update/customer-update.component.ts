import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatInputModule } from "@angular/material/input";
import { CustomerService } from '../../../core/services/customer.service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { validateHorizontalPosition } from '@angular/cdk/overlay';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { UpdateCustomerModel } from '../../../core/dataContracts/updateCustomerModel';


@Component({
  selector: 'app-customer-update',
  imports: [ReactiveFormsModule, FormsModule, RouterModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './customer-update.component.html',
  styleUrls: ['./customer-update.component.scss']
})
export class CustomerUpdateComponent {
  public customerForm: FormGroup | undefined;
  private customerId!: number;

  constructor(
    private fb: FormBuilder,
    private customerService: CustomerService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        const numericId = Number(id);
        this.customerId = numericId;

        this.customerService.getById(numericId).subscribe(customer => {
          this.customerForm = this.fb.group({
            firstName: [customer.firstName, Validators.required],
            lastName: [customer.lastName, Validators.required],
            street: [customer.street, Validators.required],
            postalCode: [customer.postalCode, Validators.required],
            appartmentNumber: [customer.appartmentNumber, Validators.required],
          });
        });
      }
    });
  }

  update() {
    if (this.customerForm!.valid) {
      const customer: UpdateCustomerModel = this.customerForm!.value;
      customer.id = this.customerId;
      this.customerService.update(customer).subscribe({
        next: (_) => {
          this.router.navigate(['/platform/customers']);
        },
        error: (err) => {
          window.alert('Customer update failed:' + err);
        }
      })
    }
  }

}