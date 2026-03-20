import { Routes } from '@angular/router';
import { Home } from './home/home';
import { ProductList } from './product-list/product-list';
import { CartComponent } from './shopping-cart/shopping-cart';
import { Register } from './register/register';
import { Login } from './login/login';
import { NotFound } from './not-found/not-found';
import { ProductDetails } from './product-details/product-details';
import { TablesComponent } from './table/TablesComponent';

export const routes: Routes = [
      {path:'',component:Home},
    {path:'product-list',component:ProductList},
     {path:'shopping-cart',component:CartComponent},
       { path: 'login', component: Login },
  { path: 'register', component: Register },
{ path: 'product-details/:productId', component: ProductDetails },
  { path: 'tables', component: TablesComponent },
    {path:'**',component:NotFound},
];
