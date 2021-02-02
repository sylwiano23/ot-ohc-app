import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { PageNotFoundComponent, BasicLayoutComponent } from "./core/shared/components";
import { LoginFormComponent } from "@app/modules/auth/components/login.component";

import { AuthGuard } from "./modules/auth/services/guard";

import { POSITION_ROUTE } from "@app/modules/position/routing";
import { FACTOR_ROUTE } from "@app/modules/factor/routing";
import { SURVEY_ROUTE } from '@app/modules/survey/routing';

const routes: Routes = [
  {
    path: "",
    redirectTo: "position",
    pathMatch: "full"
  },

  // App views
  {
    path: "",
    component: BasicLayoutComponent,
    children: [POSITION_ROUTE, FACTOR_ROUTE, SURVEY_ROUTE],
    canActivate: [AuthGuard]
  },
  {
    path: "auth",
    component: LoginFormComponent,
    pathMatch: "full"
  },
  {
    path: "**",
    component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
