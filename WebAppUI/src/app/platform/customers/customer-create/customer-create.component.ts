import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RouterModule, Router } from '@angular/router';
import { CustomerService } from '../../../core/services/customer.service';

@Component({
  selector: 'app-customer-create',
  standalone: true;
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    MatFormFieldModule,
    MatInputModule
  ],
  templateUrl: './customer-create.component.html',
  styleUrl: './customer-create.component.scss'
})
export class CustomerCreateComponent {
  customerForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private customerService: CustomerService,
    private router: Router
  )
  {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      lastName: ['', Validators.required],
      street: ['', Validators.required],
      postalCode: ['', Validators.required],
      appartmentNumber: ['', Validators.required],
    })
  }

}
