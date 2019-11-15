import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from './auth/auth.service';
import { AuthModule, OidcSecurityService } from 'angular-auth-oidc-client';
import { TitleComponent } from '../_components/title/title.component';
import { LanguageComponent } from './language/language.component';
import { LanguageService } from './language/language.service';


const COMPONENTS = [
  LanguageComponent,
  TitleComponent,
];

@NgModule({
  imports: [
    CommonModule,
    AuthModule.forRoot()
  ],
  declarations: [COMPONENTS],
  providers: [
    AuthService,
    OidcSecurityService,
    LanguageService
  ]
})
export class CoreModule { }
