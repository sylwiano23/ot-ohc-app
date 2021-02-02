import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { SharedModule } from "@app/core/shared/shared.module";

import { ROUTING } from "@app/modules/factor/routing";
import { FactorSharedModule } from "@app/modules/factor/shared.module";

import { FactorListComponent } from "./components/list/list.component";
import { FactorFormComponent } from "./components/form/form.component";

@NgModule({
  declarations: [FactorListComponent, FactorFormComponent],
  exports: [FactorListComponent, FactorFormComponent],
  imports: [ROUTING, FormsModule, ReactiveFormsModule, SharedModule, FactorSharedModule],
  providers: []
})
export class FactorModule {}
