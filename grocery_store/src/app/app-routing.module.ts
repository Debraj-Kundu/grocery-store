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
    canActivate: [AuthGuard],
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
  },
  {
    path: 'order',
    loadComponent: () =>
      import('./Views/order/order.component').then((c) => c.OrderComponent),
  },
  {
    path: ':id',
    loadComponent: () =>
      import('./Views/product/product.component').then((c) => c.ProductComponent),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
