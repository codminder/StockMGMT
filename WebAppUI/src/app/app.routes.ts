
import { Routes } from '@angular/router';
import { ProductComponent } from './platform/products/products.component';
import { LoginComponent } from './authentication/login/login.component';
import { Platform } from '@angular/cdk/platform';
import { PlatformComponent } from './platform/platform.component';

export const routes: Routes = [
    {path: '', component: PlatformComponent},
    {path: '/products/products', component: ProductComponent},
    {path: 'login', component: LoginComponent},
    /*{path: 'customers', component: CustomerComponent},*/
];
