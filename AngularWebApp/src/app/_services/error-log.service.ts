import { Injectable, NgZone } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ToastService } from './toast.service';
import * as _ from 'lodash';

@Injectable({
  providedIn: 'root'
})
export class ErrorLogService {

  constructor(
    private readonly _translateService: TranslateService,
    private readonly _toastService: ToastService,
    private readonly _ngZone: NgZone
  ) { }

  public logError = async (error: any, displayToast: boolean = true): Promise<any> => {
    // display the error in console
    this.sendToConsole(error);

    if (displayToast)
      this.displayErrorToast(error);
  }

  private sendToConsole(error: any): void {
    console.group('Angular WebApp error service');
    console.error(error);
    console.error(error.message);
    console.error(error.stack);
    console.groupEnd();
  }

  private displayErrorToast(error: any) {
    this._ngZone.run(() => {
      let message: string = '';
      if (_.isString(error))
        message = this._translateService.instant(error);
      else {
        message = error && error.message ? this._translateService.instant(error.message) : this._translateService.instant('this._somethingUnexpected');
      }
      this._toastService.showError(message, this._translateService.instant('COMMON.ERROR'));

    });
  }
}
