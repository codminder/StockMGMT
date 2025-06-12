
import { Routes } from '@angular/router';
import { ProductComponent } from './platform/products/products.component';
import { LoginComponent } from './authentication/login/login.component';

export const routes: Routes = [
    {path: '/platform/products', component: ProductComponent},
    {path: 'login', component: LoginComponent},
    /*{path: 'customers', component: CustomerComponent},*/
];
