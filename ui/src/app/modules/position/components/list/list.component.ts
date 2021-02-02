import { Component } from "@angular/core";

import { remote } from "electron";

const dialogOptions = { type: "info", buttons: ["Tak", "Nie"], cancelId: 1, message: "Czy na pewno chcesz usunąć?" };

import { PositionService } from "@app/modules/position/services/service";
import { Position } from "@app/modules/position/interfaces/position.interface";
import { finalize } from "rxjs/operators";
import { UserSessionService } from "@app/modules/user/services/user-session.service";
import { ToastrService } from "ngx-toastr";

/**
 * Component for display position screen
 */
@Component({
  selector: "position-list",
  templateUrl: "list.component.html"
})
export class PositionsListComponent {
  //region Properties

  filteredPositions: Position[] = [];

  isAdmin: boolean = false;

  busy = {
    load: true
  };

  //endregion

  constructor(
    public userSessionService: UserSessionService,
    private toastr: ToastrService,
    private positionService: PositionService
  ) {
    this.userSessionService.currentData.subscribe(data => {
      console.log(data, this.userSessionService.isAdmin, data.user.role, this.userSessionService.data.getValue());
      this.isAdmin = this.userSessionService.isAdmin;
    });

    this.loadPositions();
  }

  loadPositions() {
    this.busy.load = true;
    this.positionService.getPositions(() => (this.busy.load = false));
  }

  delete(id: number) {
    remote.dialog.showMessageBox(remote.getCurrentWindow(), dialogOptions).then(({ response }) => {
      if (response === 0) {
        this.positionService.delete(id).subscribe(response => {
          this.toastr.success("Zmiany zapisane.", "Sukces");

          this.loadPositions();
        });
      }
    });
  }

  onSearchComplete(filteredPosition: Position[]) {
    console.log({ filteredPosition });
    this.filteredPositions = filteredPosition;
  }

  trackById(index: number, item: Position) {
    return item.id;
  }
}
