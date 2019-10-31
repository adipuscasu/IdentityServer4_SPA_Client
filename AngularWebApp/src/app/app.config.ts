import { environment } from 'src/environments/environment';
import { InjectionToken } from '@angular/core';

export const APP_DI_CONFIG: AppConfig = {
  baseUrl: environment.baseUrl,
  applicationName: 'IdentityServerAngularTemplate',
  // tslint:disable-next-line:max-line-length
  emailRegex: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
  version: environment.version,
  apiUrl: 'https://localhost:44341/api/'
};

export let APP_CONFIG = new InjectionToken<AppConfig>('app.config');
