import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ErrorLogService } from './error-log.service';

@Injectable({
  providedIn: 'root'
})
export class ApiRejectionHandlerService {

  constructor(
    private readonly _translateService: TranslateService,
    private readonly _errorLogService: ErrorLogService
  ) { }

  public handleBadRequest(err: any): void {
    if (!err || err.status !== 400) {
      return;
    }

    this.handleError(err);
  }

  public handleServerError(err: any): void {
    if (!err || err.status !== 500) {
      return;
    }

    this.handleError(err);
  }

  public handleUnauthorized(err: any): void {
    if (!err || err.status !== 401) {
      return;
    }

    this.handleError(err);
  }

  public handleError(err: any) {
    console.log('error: ', err);
    if (!err.error || !err.error.message) {
      err.error = { message: 'ERRORS.UNKNOWN_ERROR' };
    }

    const errorMesage = err.error.message;

    if (this.isMessageWithParams(errorMesage)) {
      this._errorLogService.logError(new Error(this.parseMessage(errorMesage)));
    } else {
      this._translateService.get('ERRORS.' + errorMesage).subscribe(translationResult => {
        if (translationResult !== 'ERRORS.' + errorMesage) {
          this._errorLogService.logError(translationResult);
        } else {
          this._errorLogService.logError(errorMesage);
        }
      });
    }
  }

  private parseMessage(message: string): string {
    try {
      const messageObject = JSON.parse(message);

      const messageKey = 'ERRORS.' + messageObject.messageKey;
      const messageArguments = messageObject.messageArguments;

      const translatedMesage = this._translateService.instant(messageKey, messageArguments);

      return translatedMesage;
    } catch (err) {
      return 'ERRORS.UNKNOWN_ERROR';
    }
  }

  private isMessageWithParams(message: string): boolean {
    return message.indexOf('messageKey') > -1;
  }
}
