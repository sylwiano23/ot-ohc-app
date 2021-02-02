import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { FormBuilder, Validators, FormControl } from "@angular/forms";

import { finalize } from "rxjs/operators";

import { FactorService } from "@app/modules/factor/services/service";
import { Factor, IFactorForm } from "@app/modules/factor/interfaces/factor";
import { ToastrService } from "ngx-toastr";

/**
 * Component for display factor screen
 */
@Component({
  selector: "factor-form",
  templateUrl: "form.component.html"
})
export class FactorFormComponent {
  //region Properties

  factorId: number;
  typeKey: string;

  factor: Factor = new Factor();
  factorForm: any | IFactorForm;

  busy = {
    load: true,
    action: false
  };

  //endregion

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private factorService: FactorService
  ) {
    this.factorId = Number(this.route.snapshot.params.id);
    this.typeKey = this.route.snapshot.queryParams.type_key;

    if (this.factorId) {
      this.loadFactor();
    } else {
      this.factor = new Factor();
      this.initializeForm();
      this.busy.load = false;
    }
  }

  loadFactor() {
    this.busy.load = true;
    this.factorService
      .get(this.factorId)
      .pipe(finalize(() => (this.busy.load = false)))
      .subscribe(
        response => {
          this.factor = response;
          this.initializeForm();
        },
        error => {
          console.log(error);
        }
      );
  }

  create(formData: IFactorForm) {
    this.busy.action = true;
    this.factorService
      .create(formData)
      .pipe(finalize(() => (this.busy.action = false)))
      .subscribe(
        response => {
          this.toastr.success("Zmiany zapisane.", "Sukces");

          this.router.navigate(["/factor"], { queryParams: { type_key: this.typeKey } });
        },
        error => {
          console.log(error);
        }
      );
  }

  update(formData: IFactorForm) {
    this.busy.action = true;
    this.factorService
      .update({ id: this.factorId, ...formData })
      .pipe(finalize(() => (this.busy.action = false)))
      .subscribe(
        response => {
          this.toastr.success("Zmiany zapisane.", "Sukces");
          
          this.router.navigate(["/factor"], { queryParams: { type_key: this.typeKey } });
        },
        error => {
          console.log(error);
        }
      );
  }

  initializeForm() {
    this.factorForm = this.formBuilder.group({
      name: new FormControl(this.factor.name, Validators.required),
      description: "",
      factorType: this.typeKey
    });
  }

  onSubmit(formData: IFactorForm) {
    return this.factorId ? this.update(formData) : this.create(formData);
  }

  get name() {
    return this.factorForm.get("name");
  }
}
