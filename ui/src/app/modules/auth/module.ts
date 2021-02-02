import { NgModule } from "@angular/core";

import { SharedModule } from "@app/core/shared/shared.module";

import { ROUTING } from "@app/modules/auth/routing";
import { AuthSharedModule } from "@app/modules/auth/shared.module";

@NgModule({
  declarations: [],
  exports: [],
  imports: [ROUTING, SharedModule, AuthSharedModule],
  providers: []
})
export class AuthModule {}
