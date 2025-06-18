
import { Routes } from '@angular/router';
import { ProductComponent } from './platform/products/products.component';
import { LoginComponent } from './authentication/login/login.component';
import { PlatformComponent } from './platform/platform.component';
import { AuthGuard } from './core/authGuard';
import { ProductCreateComponent } from './platform/products/product-create/product-create.component';
import { Component } from '@angular/core';

export const routes: Routes = [
    {path: '', component: PlatformComponent},
    {path: 'platform', 
        canActivate: [AuthGuard],
        children: [
            {path: 'products', component: LoginComponent},
            {path: 'products/create', component: LoginComponent},
            {path: 'products/edit:id', component: LoginComponent},
            {path: 'products/:id'}
        ]
    },
    {path: 'products', component: ProductComponent},
    {path: 'login', component: LoginComponent},
    /*{path: 'customers', component: CustomerComponent},*/
];
