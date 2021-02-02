import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Injectable } from "@angular/core";

import { Observable } from "rxjs";

import { UserSessionService } from "@app/modules/user/services/user-session.service";

@Injectable()
export class AuthAdminGuard implements CanActivate {
  constructor(private userSessionService: UserSessionService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    if (!this.userSessionService.isAdmin) {
      this.router.navigate([""]);
    }
    return true;
  }
}
