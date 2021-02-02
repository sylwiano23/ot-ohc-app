import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { NgSelectModule } from "@ng-select/ng-select";
import { NgxExtendedPdfViewerModule } from "ngx-extended-pdf-viewer";
import { QuillModule } from "ngx-quill";

import { SharedModule } from "@app/core/shared/shared.module";

import { ROUTING } from "@app/modules/position/routing";
import { PositionSharedModule } from "@app/modules/position/shared.module";

import { PositionsListComponent } from "@app/modules/position/components/list/list.component";
import { PositionSearchComponent } from "@app/modules/position/components/partials/search.component";
import { PositionIssueComponent } from "@app/modules/position/components/issue/issue.component";
import { PositionFormComponent } from "@app/modules/position/components/form/form.component";
import { MappingFactorsToLabels } from "./pipes/map-factors-to-labels.pipe";

@NgModule({
  declarations: [
    PositionFormComponent,
    PositionIssueComponent,
    PositionsListComponent,
    PositionSearchComponent,
    MappingFactorsToLabels
  ],
  exports: [PositionFormComponent, PositionIssueComponent, PositionsListComponent, PositionSearchComponent],
  imports: [
    ROUTING,
    FormsModule,

    NgSelectModule,
    NgxExtendedPdfViewerModule,
    QuillModule,

    ReactiveFormsModule,
    SharedModule,
    PositionSharedModule
  ],
  providers: []
})
export class PositionModule {}
