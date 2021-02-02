import { ModuleWithProviders } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { PositionsListComponent } from "./components/list/list.component";
import { PositionIssueComponent } from "@app/modules/position/components/issue/issue.component";
import { PositionFormComponent } from "@app/modules/position/components/form/form.component";
import { AuthAdminGuard } from "../auth/services/admin-guard";

const ROUTES: Routes = [
  // positions
  {
    path: "",
    component: PositionsListComponent,
    pathMatch: "full",
    data: { title: "POSITIONS" }
  },
  // position add
  {
    path: "new",
    component: PositionFormComponent,
    pathMatch: "full",
    canActivate: [AuthAdminGuard],
    data: { title: "POSITION ADD" }
  },
  // position edit
  {
    path: ":id",
    component: PositionFormComponent,
    pathMatch: "full",
    canActivate: [AuthAdminGuard],
    data: { title: "POSITION EDIT" }
  },
  // issue
  {
    path: ":id/issue",
    component: PositionIssueComponent,
    pathMatch: "full",
    data: { title: "POSITION ISSUE" }
  }
];

export const ROUTING: ModuleWithProviders = RouterModule.forChild(ROUTES);

// Route for lazy loading
export const POSITION_ROUTE = {
  path: "position",
  loadChildren: () => import("app/modules/position/module").then(m => m.PositionModule),
  data: {
    i18n: ["position"]
  },
  canActivate: []
};
