import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { FormBuilder, FormControl, Validators } from "@angular/forms";

import { QuillModules } from "ngx-quill";
import { finalize } from "rxjs/operators";

import { PositionService } from "@app/modules/position/services/service";
import { Position, IPositionForm, PositionPayload } from "@app/modules/position/interfaces/position.interface";
import { Factor } from "@app/modules/factor/interfaces/factor";
import { FactorService } from "@app/modules/factor/services/service";
import { Subscription } from "rxjs";
import { ToastrService } from "ngx-toastr";

const EDITOR_TOOLBAR_CONFIG: QuillModules = {
  toolbar: [
    ["bold", "italic", "underline", "strike"], // toggled buttons
    ["blockquote", "code-block"],

    [{ header: 1 }, { header: 2 }], // custom button values
    [{ list: "ordered" }, { list: "bullet" }],
    [{ script: "sub" }, { script: "super" }], // superscript/subscript
    [{ indent: "-1" }, { indent: "+1" }], // outdent/indent
    [{ direction: "rtl" }], // text direction

    [{ color: [] }, { background: [] }], // dropdown with defaults from theme

    [{ align: [] }],

    ["clean"], // remove formatting button

    ["link"] // link and image, video
  ]
};

/**
 * Component for display position screen
 */
@Component({
  selector: "position-form",
  templateUrl: "form.component.html"
})
export class PositionFormComponent implements OnInit {
  //region Properties

  positionId: number;

  position: Position = new Position();
  positionForm: any | IPositionForm;

  EDITOR_TOOLBAR_CONFIG: QuillModules = EDITOR_TOOLBAR_CONFIG;

  factors: { [key: string]: Factor[] } = {};

  busy = {
    load: true,
    save: false
  };

  subs: Subscription = new Subscription();

  //endregion

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private positionService: PositionService,
    private factorService: FactorService
  ) {}

  ngOnInit() {
    this.factorService.loadAllFactors();

    this.positionId = Number(this.route.snapshot.params.id);

    this.subs.add(
      this.factorService.factors.subscribe(factors => {
        this.factors = factors;
      })
    );

    if (this.positionId) {
      this.loadPosition();
    } else {
      this.position = new Position();
      this.initializeForm();
      this.busy.load = false;
    }
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  loadPosition() {
    this.busy.load = true;
    this.positionService
      .get(this.positionId)
      .pipe(finalize(() => (this.busy.load = false)))
      .subscribe(
        response => {
          this.position.id = response.id;
          this.position.name = response.name;
          this.position.description = response.description;

          this.position.dust = response.factors["Dust"] || [];
          this.position.chemical_agents = response.factors["Chemical"] || [];
          this.position.biological_factors = response.factors["Biological"] || [];
          this.position.physical_factors = response.factors["Physical"] || [];
          this.position.other_hazardous_factors = response.factors["Other"] || [];

          this.initializeForm();
        },
        error => {
          console.log(error);
        }
      );
  }

  create(formData: PositionPayload) {
    this.busy.save = true;
    this.positionService
      .create(formData)
      .pipe(finalize(() => (this.busy.save = false)))
      .subscribe(
        response => {
          this.toastr.success("Zmiany zapisane.", "Sukces");

          this.router.navigateByUrl("/position");
        },
        error => {
          console.log(error);
        }
      );
  }

  update(formData: PositionPayload) {
    this.busy.save = true;
    this.positionService
      .update(formData)
      .pipe(finalize(() => (this.busy.save = false)))
      .subscribe(
        response => {
          this.toastr.success("Zmiany zapisane.", "Sukces");

          this.router.navigateByUrl("/position");
        },
        error => {
          console.log(error);
        }
      );
  }

  onSubmit(formData: IPositionForm) {
    let data = new PositionPayload({ id: this.positionId, ...formData });

    return this.positionId ? this.update(data) : this.create(data);
  }

  initializeForm() {
    this.positionForm = this.formBuilder.group({
      name: new FormControl(this.position.name, Validators.required),
      description: new FormControl(this.position.description, Validators.required),
      dust: new FormControl(this.position.dust),
      chemical_agents: new FormControl(this.position.chemical_agents),
      biological_factors: new FormControl(this.position.biological_factors),
      physical_factors: new FormControl(this.position.physical_factors),
      other_hazardous_factors: new FormControl(this.position.other_hazardous_factors)
    });
  }

  get name() {
    return this.positionForm.get("name");
  }

  get description() {
    return this.positionForm.get("description");
  }

  get hazardousFactorsNumberTotal(): number {
    let total = 0;
    total += this.positionForm.get("dust").value.length;
    total += this.positionForm.get("chemical_agents").value.length;
    total += this.positionForm.get("physical_factors").value.length;
    total += this.positionForm.get("biological_factors").value.length;
    total += this.positionForm.get("other_hazardous_factors").value.length;
    return total;
  }
}
