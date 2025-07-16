// src/app/interceptors/global-error.interceptor.ts
import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

export const GlobalErrorInterceptor: HttpInterceptorFn = (req, next) => {
  const snackBar = inject(MatSnackBar);

  return next(req).pipe(
    catchError((error) => {
      if (error.status >= 500 || error.status === 0) {
        snackBar.open('Something went wrong. Please try again later.', 'Close', {
          duration: 5000,
          panelClass: ['snackbar-error'],
        });
      }

      return throwError(() => error);
    })
  );
};