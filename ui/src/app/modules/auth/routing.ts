import { ModuleWithProviders } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { LoginFormComponent } from "@app/modules/auth/components/login.component";

const ROUTES: Routes = [
  // login
  {
    path: "",
    component: LoginFormComponent,
    pathMatch: "full",
    data: { title: "LOGIN" }
  }
];

export const ROUTING: ModuleWithProviders = RouterModule.forChild(ROUTES);

// Route for lazy loading
export const AUTH_ROUTE = {
  path: "auth",
  loadChildren: () => import("app/modules/auth/module").then(m => m.AuthModule),
  data: {
    i18n: ["auth"]
  },
  canActivate: []
};
