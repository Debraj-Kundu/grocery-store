import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './Guard/auth.guard';

const routes: Routes = [
  {
    path: 'login',
    loadComponent: () =>
      import('./Core/login/login.component').then((c) => c.LoginComponent),
  },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full',
  },
  {
    path: 'register',
    loadComponent: () =>
      import('./Core/register/register.component').then(
        (c) => c.RegisterComponent
      ),
  },
  {
    path: 'home',
    loadComponent: () =>
      import('./Views/home/home.component').then((c) => c.HomeComponent),
  },
  {
    path: 'cart',
    loadComponent: () =>
      import('./Views/cart/cart.component').then((c) => c.CartComponent),
    canActivate: [AuthGuard],
  },
  {
    path: 'order',
    loadComponent: () =>
      import('./Views/order/order.component').then((c) => c.OrderComponent),
    canActivate: [AuthGuard],
  },
  {
    path: 'product/:id',
    loadComponent: () =>
      import('./Views/product/product.component').then(
        (c) => c.ProductComponent
      ),
  },
  {
    path: 'edit/:id',
    loadComponent: () =>
      import('./Views/edit-product/edit-product.component').then(
        (c) => c.EditProductComponent
      ),
    canActivate: [AuthGuard],
  },
  {
    path: 'add',
    loadComponent: () =>
      import('./Views/add-product/add-product.component').then(
        (c) => c.AddProductComponent
      ),
    canActivate: [AuthGuard],
  },
  {
    path: 'toporder',
    loadComponent: () =>
      import('./Views/top-orders/top-orders.component').then(
        (c) => c.TopOrdersComponent
      ),
    canActivate: [AuthGuard],
  },
  {
    path: '**',
    loadComponent: () =>
      import('./Core/error-page/error-page.component').then(
        (c) => c.ErrorPageComponent
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
