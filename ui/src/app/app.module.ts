import "reflect-metadata";
import "../polyfills";

import { BrowserModule } from "@angular/platform-browser";
import { NgModule, ErrorHandler } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from "@angular/common/http";
import { CoreModule } from "./core/core.module";

import { AppRoutingModule } from "./app-routing.module";

// NG Translate
import { TranslateModule, TranslateLoader } from "@ngx-translate/core";
import { TranslateHttpLoader } from "@ngx-translate/http-loader";
import { ToastrModule } from "ngx-toastr";
import { QuillModule } from "ngx-quill";

import { AppComponent } from "./app.component";
import { SharedModule } from "./core/shared/shared.module";
import { FactorService } from "./modules/factor/services/service";
import { FactorResource } from "./modules/factor/resources/resource";
import { AuthSharedModule } from "./modules/auth/shared.module";
import { UserSessionService } from "./modules/user/services/user-session.service";
import { AuthAdminGuard } from "./modules/auth/services/admin-guard";
import { AuthGuard } from "./modules/auth/services/guard";
import { HttpConfigInterceptor } from "./httpconfig.interceptor";
import { GlobalErrorHandler, ErrorLogService } from "./core/services";

// AoT requires an exported function for factories
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, "./assets/i18n/", ".json");
}

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    CoreModule,
    SharedModule,
    AuthSharedModule,
    AppRoutingModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    QuillModule.forRoot(),
    BrowserAnimationsModule, // required animations module for toaster
    ToastrModule.forRoot({
      timeOut: 2500,
      positionClass: "toast-bottom-right",
      preventDuplicates: true
    })
  ],
  providers: [
    {
      provide: ErrorHandler,
      useClass: GlobalErrorHandler
    },
    ErrorLogService,

    { provide: HTTP_INTERCEPTORS, useClass: HttpConfigInterceptor, multi: true },

    FactorService,
    FactorResource,
    UserSessionService,
    AuthGuard,
    AuthAdminGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
