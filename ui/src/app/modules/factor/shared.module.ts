import { NgModule } from "@angular/core";

import { SharedModule } from "@app/core/shared/shared.module";

import { FactorResource } from "@app/modules/factor/resources/resource";
import { FactorService } from "@app/modules/factor/services/service";

@NgModule({
  declarations: [],
  exports: [],
  imports: [SharedModule],
  providers: [FactorResource, FactorService]
})
export class FactorSharedModule {}
