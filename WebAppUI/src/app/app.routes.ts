
import { Routes } from '@angular/router';
import { ProductComponent } from './platform/products/products.component';
import { LoginComponent } from './authentication/login/login.component';
import { AuthGuard } from './core/authGuard';
import { ProductCreateComponent } from './platform/products/product-create/product-create.component';
import { ProductUpdateComponent } from './platform/products/product-update/product-update.component';

export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    {
        path: 'platform',
 //       canActivate: [AuthGuard],
        children: [
            {
                path: 'products', children: [
                    
                    { path: 'create', component: ProductCreateComponent },
                    { path: 'edit/:id', component: ProductUpdateComponent },
                    { path: 'update', component: ProductComponent },
                    { path: ':id', component: ProductComponent },
                    { path: '', component: ProductComponent }
                ]
            }
        ]
    }
];
