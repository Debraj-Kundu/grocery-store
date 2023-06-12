import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserStoreService {
  private fullname$ = new BehaviorSubject<string>('');
  private role$ = new BehaviorSubject<string>('');

  constructor() {}

  public getRoleFormStore(): Observable<string> {
    return this.role$.asObservable();
  }
  public setRoleForStore(role: string) {
    this.role$.next(role);
  }

  public getfullnameFormStore(): Observable<string> {
    return this.fullname$.asObservable();
  }
  public setfullnameForStore(fullname: string) {
    this.fullname$.next(fullname);
  }
}
