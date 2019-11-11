import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { config } from 'process';


@Injectable({ providedIn: 'root' })

export class UserService {
  private readonly _usersApiUrl: string = 'https://localhost:44341/api/Users';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private originUrl: string,
    @Inject('API_URL') private apiUrl: string,
    ) { }

  getAll(freeText: string = '', includeDeactivated: boolean = false) {
    let httpParams: HttpParams = new HttpParams({
      fromObject: {
          includeDeactivated: includeDeactivated ? 'true' : 'false'
      }
  });

  if (freeText)
      httpParams = httpParams.append('freeText', freeText);

    return this.http.get<IUser[]>(`${this._usersApiUrl}`, {params: httpParams});
  }

  register(user: IUser) {
    return this.http.post(`${this._usersApiUrl}/register`, user);
  }

  delete(id: number) {
    return this.http.delete(`${this._usersApiUrl}${id}`);
  }
}
