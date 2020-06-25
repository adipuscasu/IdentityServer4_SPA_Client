import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly _usersApiUrl: string = 'Users';

  constructor(
    private readonly _httpClient: HttpClient

  ) { }

  public getAll() {
    return this._httpClient.get<Array<IUser>>(this._usersApiUrl);
  }
  public getById(id: string): Observable<IUser> {
    return this._httpClient.get<IUser>(`${this._usersApiUrl}/${id}`);
  }
  public update(user: IUser, completedWizard: boolean = null): Observable<string> {
    let httpParams = new HttpParams();

    if (completedWizard === true)
      httpParams = httpParams.append('completedWizard', true.toString());

    return this._httpClient.put<string>(`${this._usersApiUrl}/${user.id}`, user, { params: httpParams });
  }
}
