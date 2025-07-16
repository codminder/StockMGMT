import { HttpInterceptorFn } from '@angular/common/http';

export const AuthInterceptor: HttpInterceptorFn = (req, next) => {
    const token = localStorage.getItem('token');
    if (token) {
        const authReq = req.clone({
            setHeaders: { Authorization: `Bearer ${token}` }
        });
        return next(authReq);
    }

    // Laat alle andere requests ongemoeid
    return next(req);
};