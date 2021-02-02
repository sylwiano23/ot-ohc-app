import { Component } from "@angular/core";

import { UserSessionService } from "@app/modules/user/services/user-session.service";

@Component({
  selector: "basic",
  templateUrl: "basic-layout.component.html"
})
export class BasicLayoutComponent {
  public isAuthorized: boolean = false;

  constructor(private userSessionService: UserSessionService) {
    this.userSessionService.currentData.subscribe(data => {
      this.isAuthorized = !!data.accessToken;
    });
  }

  //region Accessors

  //endregion

  //region Life cycle

  //endregion

  //region Event listeners

  //endregion
}
