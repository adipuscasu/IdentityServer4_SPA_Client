import { Injectable, Injector } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../auth/auth.service';
import { ApiRejectionHandlerService } from 'src/app/_services/api-rejection-handler.service';


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(
    private authenticationService: AuthService,
    private readonly _injector: Injector,
    private readonly _apiRejectionHandlerService: ApiRejectionHandlerService
  ) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {
      console.log('intercepting: ', err);
      if (err.status === 401) {
        // auto logout if 401 response returned from api
        this.authenticationService.logout();
        location.reload();
      }
      if (err.status === 400) {
        this._apiRejectionHandlerService.handleError(err);
      } else if (err.status === 500) {
        this._apiRejectionHandlerService.handleServerError(err);
      } else {
        this.handleError(err);
      }

      const error = err.error.message || err.statusText;
      return throwError(error);
    }));
  }

  public handleError(error: any): void {
    try {
      const apiRejectionHandlerService = this._injector.get(ApiRejectionHandlerService);

      console.error(error);

      apiRejectionHandlerService.handleError(this.findOriginalError(error));
    } catch {
      // nothing to see here
    }
  }

  private findOriginalError(error: any): any {
    while (error && error.originalError)
      error = error.originalError;

    if (error && error.rejection)
      error = error.rejection;

    return error;
  }
}
