import { NgModule } from "@angular/core";

import { SharedModule } from "@app/core/shared/shared.module";

import { SurveyResource } from "@app/modules/survey/resources/resource";
import { SurveyService } from "@app/modules/survey/services/service";

@NgModule({
  declarations: [],
  exports: [],
  imports: [SharedModule],
  providers: [SurveyResource, SurveyService]
})
export class SurveySharedModule {}
