import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../Shared/Service/login.service';

export const AuthGuard = () => {
  const router = inject(Router);
  const loginService = inject(LoginService);
  if (loginService.isLoggedIn()) {
    return true;
  }
  router.navigate(['/login']);
  return false;
};
