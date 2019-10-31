import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../_models';
import { config } from 'process';


@Injectable({ providedIn: 'root' })

export class UserService {
  private readonly registrationApiUrl: string = 'https://localhost:44341/api/Users';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private originUrl: string,
    @Inject('API_URL') private apiUrl: string,
    ) { }

  getAll() {
    return this.http.get<User[]>(`${config.apiUrl}/users`);
  }

  register(user: User) {
    return this.http.post(`${this.registrationApiUrl}/register`, user);
  }

  delete(id: number) {
    return this.http.delete(`${config.apiUrl}/users/${id}`);
  }
}
