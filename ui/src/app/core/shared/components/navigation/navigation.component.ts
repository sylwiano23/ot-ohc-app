import { Component } from "@angular/core";
import { Router } from "@angular/router";

import { UserSessionService } from "@app/modules/user/services/user-session.service";

@Component({
  selector: "navigation",
  templateUrl: "navigation.component.html"
})
export class NavigationComponent {
  public isAdmin: boolean = false;

  constructor(private router: Router, private userSessionService: UserSessionService) {
    this.userSessionService.currentData.subscribe(data => {
      this.isAdmin = this.userSessionService.isAdmin;
    });
  }

  //region Accessors

  //endregion

  //region Life cycle

  //endregion

  //region Event listeners

  logout() {
    this.userSessionService.destroyData();

    this.router.navigateByUrl("auth");
  }

  //endregion
}
