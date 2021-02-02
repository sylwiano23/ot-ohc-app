import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { TranslateModule } from "@ngx-translate/core";

import { PageNotFoundComponent, BasicLayoutComponent, NavigationComponent } from "./components/";
import { WebviewDirective } from "./directives/";
import { SafePipe } from "./pipes/safe.pipe";
import { Mapping } from "./pipes/map.pipe";

@NgModule({
  declarations: [BasicLayoutComponent, NavigationComponent, PageNotFoundComponent, WebviewDirective, SafePipe, Mapping],
  imports: [RouterModule, CommonModule, TranslateModule],
  exports: [RouterModule, CommonModule, TranslateModule, WebviewDirective, SafePipe, Mapping]
})
export class SharedModule {}
