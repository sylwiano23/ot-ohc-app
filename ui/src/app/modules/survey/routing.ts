import { ModuleWithProviders } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { SurveyListComponent } from "./components/list/list.component";
import { SurveyFormComponent } from "./components/form/form.component";
import { AuthAdminGuard } from "../auth/services/admin-guard";

const ROUTES: Routes = [
  // surveys
  {
    path: "",
    component: SurveyListComponent,
    pathMatch: "full",
    data: { title: "SURVEYS" }
  },
  // survey add
  {
    path: "new",
    component: SurveyFormComponent,
    canActivate: [AuthAdminGuard],
    pathMatch: "full",
    data: { title: "SURVEY ADD" }
  },
  // survey edit
  {
    path: ":id",
    component: SurveyFormComponent,
    canActivate: [AuthAdminGuard],
    pathMatch: "full",
    data: { title: "SURVEY EDIT" }
  }
];

export const ROUTING: ModuleWithProviders = RouterModule.forChild(ROUTES);

// Route for lazy loading
export const SURVEY_ROUTE = {
  path: "survey",
  loadChildren: () => import("app/modules/survey/module").then(m => m.SurveyModule),
  data: {
    i18n: ["survey"]
  },
  canActivate: []
};
