import { NgModule } from "@angular/core";
import { MatNativeDateModule } from "@angular/material/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatFormFieldModule } from "@angular/material/form-field";

import { NgSelectModule } from "@ng-select/ng-select";

import { SharedModule } from "@app/core/shared/shared.module";

import { ROUTING } from "@app/modules/survey/routing";
import { SurveySharedModule } from "@app/modules/survey/shared.module";
import { PositionSharedModule } from "@app/modules/position/shared.module";

import { SurveyListComponent } from "./components/list/list.component";
import { SurveyFormComponent } from "./components/form/form.component";
import { SortDirection } from "./pipes/sort-direction.pipe";

@NgModule({
  declarations: [SurveyListComponent, SurveyFormComponent, SortDirection],
  exports: [SurveyListComponent, SurveyFormComponent],
  imports: [
    ROUTING,

    FormsModule,
    ReactiveFormsModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatFormFieldModule,
    NgSelectModule,

    SharedModule,
    SurveySharedModule,
    PositionSharedModule
  ],
  providers: [MatNativeDateModule]
})
export class SurveyModule {}
