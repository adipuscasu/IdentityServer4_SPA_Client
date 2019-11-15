import { Injectable } from '@angular/core';
import { TranslateService, LangChangeEvent } from '@ngx-translate/core';
import { UserService } from 'src/app/_services/user.service';
import * as  moment from 'moment';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  private _defaultLanguage: string = LanguageEnum.English;
  private _initialLanguage: string = LanguageEnum.English;
  constructor(
    private readonly _translateService: TranslateService,
    private readonly _userService: UserService,
    private readonly _authservice: AuthService
  ) {
    this.onLanguageChange();
  }

  private onLanguageChange() {
    const source = this._translateService
      .onLangChange;

    source
      .subscribe((event: LangChangeEvent) => {
        moment.locale(event.lang.split('_')[0]);
      });

    return source;
  }

  public initLanguage() {
    const loggedUser = this._authservice.currentUserValue;

    this._translateService.setDefaultLang(this._defaultLanguage);
    this._translateService.use(this._initialLanguage);
  }

  public changeLanguage = async (language: LanguageEnum, skipServerUpdate: boolean = true) => {
    if (!language)
      language = LanguageEnum.English;

    this._translateService.setDefaultLang(language);

    this._translateService.use(language);

    if (!skipServerUpdate) { return; }

    // update user's language on backend
    // await this._userService.changeLanguage(this._credentialsService.getUser().id, language).toPromise();
  }

  public get currentLanguage(): LanguageEnum {
    return this._translateService.currentLang as LanguageEnum;
  }
}


export enum LanguageEnum {
  English = 'en_US',
  //Norwegian = 'nb_NO'
}
export enum LanguageDisplayMode {
  Login = 0,
  Navbar = 1
}
