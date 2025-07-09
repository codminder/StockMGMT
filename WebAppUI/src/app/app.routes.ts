
import { Routes } from '@angular/router';
import { ProductComponent } from './platform/products/products.component';
import { LoginComponent } from './authentication/login/login.component';
import { AuthGuard } from './core/authGuard';
import { ProductCreateComponent } from './platform/products/product-create/product-create.component';
import { ProductUpdateComponent } from './platform/products/product-update/product-update.component';
import { CustomerCreateComponent } from './platform/customers/customer-create/customer-create.component';
import { CustomerUpdateComponent } from './platform/customers/customer-update/customer-update.component';
import { CustomersComponent } from './platform/customers/customers.component';
import { PlatformComponent } from './platform/platform.component';

export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    {
        path: 'platform',
        canActivate: [AuthGuard],
        component: PlatformComponent,
        children: [
            {
                path: 'products', children: [
                    
                    { path: 'create', component: ProductCreateComponent },
                    { path: 'edit/:id', component: ProductUpdateComponent },
                    { path: 'update', component: ProductComponent },
                    { path: ':id', component: ProductComponent },
                    { path: '', component: ProductComponent }
                ]
            },
            {
                path: 'customers', children:[
                    { path: 'create', component: CustomerCreateComponent },
                    { path: 'update', component: CustomerUpdateComponent },
                    { path: ':id', component: CustomersComponent },
                    { path: '', component: CustomersComponent }
                ]
            }
        ]
    },
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: '**', redirectTo: 'login' }
];
