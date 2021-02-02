import { ModuleWithProviders } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { FactorListComponent } from "./components/list/list.component";
import { FactorFormComponent } from "./components/form/form.component";
import { AuthAdminGuard } from "../auth/services/admin-guard";

const ROUTES: Routes = [
  // factors
  {
    path: "",
    component: FactorListComponent,
    pathMatch: "full",
    data: { title: "FACTORS" }
  },
  // factor add
  {
    path: "new",
    component: FactorFormComponent,
    canActivate: [AuthAdminGuard],
    pathMatch: "full",
    data: { title: "FACTOR ADD" }
  },
  // factor edit
  {
    path: ":id",
    component: FactorFormComponent,
    canActivate: [AuthAdminGuard],
    pathMatch: "full",
    data: { title: "FACTOR EDIT" }
  }
];

export const ROUTING: ModuleWithProviders = RouterModule.forChild(ROUTES);

// Route for lazy loading
export const FACTOR_ROUTE = {
  path: "factor",
  loadChildren: () => import("app/modules/factor/module").then(m => m.FactorModule),
  data: {
    i18n: ["factor"]
  },
  canActivate: []
};
