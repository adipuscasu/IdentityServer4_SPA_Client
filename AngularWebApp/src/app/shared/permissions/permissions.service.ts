import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PermissionsService {

  constructor() { }
}

export enum Role {
  Admin = 'ADMIN',
  User = 'USER'
}
