import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor(
    private readonly _toastrService: ToastrService,
    private readonly _translateService: TranslateService,
  ) { }
  public showSuccess(message: string, title: string = 'COMMON.SUCCESS', closeButton: boolean = true) {
    message = this._translateService.instant(message);
    title = !!title ? this._translateService.instant(title) : this._translateService.instant('COMMON.SUCCESS');

    this._toastrService.success(message, title, {
      closeButton: closeButton
    });
  }

  public showWarning(message: string, title: string = 'COMMON.WARNING', closeButton: boolean = true) {
    message = this._translateService.instant(message);
    title = !!title ? this._translateService.instant(title) : this._translateService.instant('COMMON.WARNING');

    this._toastrService.warning(message, title, {
      closeButton: closeButton
    });
  }

  public showError(message: string, title: string = 'COMMON.ERROR', closeButton: boolean = true) {
    message = this._translateService.instant(message);
    title = !!title ? this._translateService.instant(title) : this._translateService.instant('COMMON.ERROR');

    const errorActiveToast = this._toastrService.error(message, title, {
      closeButton: closeButton
    });
    errorActiveToast.onAction
      .pipe(take(1)) // will unsubscribe automatically after the first execution
      .subscribe((action) => {
        // todo something
      });
  }
}
