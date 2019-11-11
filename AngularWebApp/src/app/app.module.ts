import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AgGridModule } from 'ag-grid-angular';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { CoreModule } from './core/core.module';
import { AlertComponent } from './_components/alert';
import { RegisterComponent } from './register/register.component';
import { AppRoutingModule } from './app-routing.module';
import { ErrorInterceptor } from './core/error/error.interceptor';
import { AuthInterceptor } from './core/auth/auth.interceptor';
import { ToastrModule } from 'ngx-toastr';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { ApGridComponent } from './_components/grid/ap-grid/ap-grid.component';
import { UsersModule } from './users/users.module';
import { UsersComponent } from './users/users.component';
import { SmGridComponent } from './_components/sm-grid/sm-grid.component';
import { library } from '@fortawesome/fontawesome-svg-core';
import { FONT_AWESOME_ICONS_BOLD } from './font-awesome-bold';
import { LanguageComponent } from './_components/language/language.component';


export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

const COMPONENTS = [
  AppComponent,
  NavMenuComponent,
  HomeComponent,
  CounterComponent,
  FetchDataComponent,
  UnauthorizedComponent,
  AlertComponent,
  RegisterComponent,
  ApGridComponent,
  SmGridComponent,
];

const MODULES = [
  UsersModule,
  AppRoutingModule,

]

const VENDOR_MODULES = [
  TranslateModule.forRoot({
    loader: {
      provide: TranslateLoader,
      useFactory: (createTranslateLoader),
      deps: [HttpClient]
    }
  }),
  ToastrModule.forRoot({
    positionClass: 'toast-bottom-right',
    // toastComponent: CustomToastComponent // added custom toast!
  }),
  // NgxFileDropModule,
  // PerfectScrollbarModule,
  // ArchwizardModule,
  // RxReactiveFormsModule,
  BrowserModule,
  BrowserAnimationsModule,
  HttpClientModule,
  FontAwesomeModule,
  FormsModule,
  ReactiveFormsModule,
  AgGridModule.withComponents([]),
  // InViewportModule,
  // LayoutModule,
  // PdfViewerModule,
  // DragDropModule,
  // CKEditorModule,
  // CKEditorModule,
  // ChartsModule
];
@NgModule({
  declarations: [
    COMPONENTS,
    LanguageComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    CoreModule,
    AgGridModule.withComponents([]),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: (createTranslateLoader),
        deps: [HttpClient]
      }
    }),
    MODULES,
    ToastrModule.forRoot(), // ToastrModule added
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {
    library.add(
      ...FONT_AWESOME_ICONS_BOLD
    );
  }
}
