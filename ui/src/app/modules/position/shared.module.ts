import { NgModule } from "@angular/core";

import { SharedModule } from "@app/core/shared/shared.module";

import { PositionResource } from "@app/modules/position/resources/resource";
import { PositionService } from "@app/modules/position/services/service";

@NgModule({
  declarations: [],
  exports: [],
  imports: [SharedModule],
  providers: [PositionResource, PositionService]
})
export class PositionSharedModule {}
