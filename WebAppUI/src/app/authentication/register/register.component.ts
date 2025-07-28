import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../core/services/auth.service';
import { Router, RouterModule } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { RegisterDto } from '../../core/dataContracts/registerDto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, RouterModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  public submitted = false;
  public registerForm: FormGroup<{
    firstName: FormControl<string>;
    lastName: FormControl<string>;
    street: FormControl<string>;
    postalCode: FormControl<string>;
    appartmentNumber: FormControl<number>;
    email: FormControl<string>;
    password: FormControl<string>;
    confirmPassword: FormControl<string>;
  }>;
  
  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.registerForm = this.fb.group({
      firstName: this.fb.nonNullable.control('', Validators.required),
      lastName: this.fb.nonNullable.control('', Validators.required),
      street: this.fb.nonNullable.control('', Validators.required),
      postalCode: this.fb.nonNullable.control('',Validators.required),
      appartmentNumber: this.fb.nonNullable.control('', Validators.required),
      email: this.fb.nonNullable.control('', [Validators.required, Validators.email]),
      password: this.fb.nonNullable.control('', [Validators.required, Validators.minLength(8)]),
      confirmPassword: this.fb.nonNullable.control('', Validators.required)
    }, { validators: this.passwordMatchValidator});
  }

  public get f () {
    return this.registerForm.controls;
  }

  public passwordMatchValidator(form: FormGroup): null | {mismatch: true} {
    const password = form.get('password')?.value;
    const confirmPassword = form.get('confirmPassword')?.value;

    return password === confirmPassword ? null : { mismatch: true };
  }

  public register(): void {
    if (this.registerForm.valid) {
      const { firstName, lastName, street, postalCode, appartmentNumber, email, password } = this.registerForm.getRawValue();

      const registerDto: RegisterDto = { firstName, lastName, street, postalCode, appartmentNumber, email, password };

      this.authService.register(registerDto).subscribe({
        next: (result: any) => {
          localStorage.setItem('token', result.token);
          this.router.navigate(['/platform/products']);
        },
        error: (err: string) => {
          console.log('Register failed', err);
        }
      });
    }
  }
}
