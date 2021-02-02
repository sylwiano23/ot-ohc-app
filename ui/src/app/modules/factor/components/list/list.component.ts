import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

import { finalize } from "rxjs/operators";

import { remote } from "electron";

const dialogOptions = { type: "info", buttons: ["Tak", "Nie"], cancelId: 1, message: "Czy na pewno chcesz usunąć?" };

import { FactorService, FACTOR_TYPES_NAMES } from "@app/modules/factor/services/service";
import { Factor } from "@app/modules/factor/interfaces/factor";
import { FactorTypeEnum } from "@app/core/interfaces/types.interface";
import { UserSessionService } from "@app/modules/user/services/user-session.service";
import { ToastrService } from "ngx-toastr";

/**
 * Component for display factor screen
 */
@Component({
  selector: "factor-list",
  templateUrl: "list.component.html"
})
export class FactorListComponent {
  //region Properties

  typeKey: string;

  factors: Factor[] = [];

  isAdmin: boolean = false;

  FACTOR_TYPES_NAMES: any = FACTOR_TYPES_NAMES;

  busy = {
    load: true
  };

  //endregion

  constructor(
    public userSessionService: UserSessionService,
    private factorService: FactorService,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) {
    this.route.queryParams.subscribe(queryParams => {
      let typeKey = queryParams["type_key"];

      this.typeKey = typeKey;

      this.loadFactors();
    });

    this.userSessionService.currentData.subscribe(data => {
      this.isAdmin = this.userSessionService.isAdmin;
    });
  }

  loadFactors() {
    this.busy.load = true;
    this.factorService
      // .list(FactorTypeEnum[this.typeKey])
      .list(this.typeKey)
      .pipe(finalize(() => (this.busy.load = false)))
      .subscribe(
        response => {
          this.factors = response.factors;

          this.factorService.factors.next(
            Object.assign(this.factorService.factors.value, { [this.typeKey]: response.factors })
          );
        },
        error => {
          console.log(error);
        }
      );
  }

  delete(factorId: number) {
    remote.dialog.showMessageBox(remote.getCurrentWindow(), dialogOptions).then(({ response }) => {
      if (response === 0) {
        this.factorService.delete(factorId).subscribe(
          response => {
            this.toastr.success("Zmiany zapisane.", "Sukces");

            this.loadFactors();
          },
          error => {
            console.log(error);
          }
        );
      }
    });
  }

  trackById(index: number, item: Factor) {
    return item.id;
  }
}
