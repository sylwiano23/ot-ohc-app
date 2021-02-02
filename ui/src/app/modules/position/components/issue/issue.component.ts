import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { FormBuilder, FormControl, Validators } from "@angular/forms";

import { finalize } from "rxjs/operators";

import { PositionService } from "@app/modules/position/services/service";
import { IIssueForm, PositionView } from "@app/modules/position/interfaces/position.interface";
import { isValidPesel } from "@app/core/helpers/pesel-validation.helper";
import { FactorService } from "@app/modules/factor/services/service";
import { Factor, IHashFactors } from "@app/modules/factor/interfaces/factor";
import { Subscription } from "rxjs";

interface Option {
  id: string;
  label: string;
}

/**
 * Component for display position screen
 */
@Component({
  selector: "position-issue",
  templateUrl: "issue.component.html"
})
export class PositionIssueComponent implements OnInit {
  //region Properties

  positionId: number;

  position: PositionView = new PositionView();

  issueForm: any | IIssueForm = this.formBuilder.group({
    positionName: new FormControl("", Validators.required),
    name: new FormControl("", Validators.required),
    surname: new FormControl("", Validators.required),
    peselNumber: new FormControl("", [
      Validators.required,
      Validators.maxLength(11),
      Validators.minLength(11),
      Validators.pattern(/^-?(0|[1-9]\d*)?$/)
    ]),
    certificateType: new FormControl(null, Validators.required),
    sexType: new FormControl(null, Validators.required),
    street: new FormControl(null, Validators.required),
    houseNumber: new FormControl(null, Validators.required),
    city: new FormControl(null, Validators.required)
  });

  factors: IHashFactors = {};

  certificateTypes: Option[] = [
    {
      id: "Initial",
      label: "Wstępne"
    },
    {
      id: "Periodic",
      label: "Okresowe"
    },
    {
      id: "Control",
      label: "Kontrolne"
    }
  ];

  sexTypes: Option[] = [
    {
      id: "Male",
      label: "Mężczyzna"
    },
    {
      id: "Female",
      label: "Kobieta"
    }
  ];

  certificateBase64: string = "";

  busy = {
    load: true,
    print: false
  };

  subs: Subscription = new Subscription();

  //endregion

  constructor(
    private positionService: PositionService,
    private factorService: FactorService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder
  ) {
    this.subs.add(
      this.factorService.factors.subscribe(factors => {
        this.factors = factors;
      })
    );
  }

  ngOnInit() {
    this.factorService.loadAllFactors();

    this.positionId = Number(this.route.snapshot.params.id);

    this.loadPosition();
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  loadPosition() {
    this.busy.load = true;
    this.positionService
      .get(this.positionId, { with_values: "1" })
      .pipe(finalize(() => (this.busy.load = false)))
      .subscribe(
        response => {
          this.position = response;

          this.issueForm.get("positionName").setValue(this.position.name);

          this.position.total_hazardous_factors = 0;

          this.position.total_hazardous_factors += this.position.factors["Dust"].length;
          this.position.total_hazardous_factors += this.position.factors["Chemical"].length;
          this.position.total_hazardous_factors += this.position.factors["Physical"].length;
          this.position.total_hazardous_factors += this.position.factors["Biological"].length;
          this.position.total_hazardous_factors += this.position.factors["Other"].length;
        },
        error => {
          console.log(error);
        }
      );
  }

  print(formData: IIssueForm) {
    console.log(formData);

    let data = { positionId: this.positionId, ...formData };

    this.busy.print = true;
    this.positionService
      .issueCertificate(data)
      .pipe(finalize(() => (this.busy.print = false)))
      .subscribe(
        response => {
          // handle PDF base64
          this.certificateBase64 = `${response.file}`;
        },
        error => {
          console.log(error);
        }
      );
  }

  public factorsToLabels = (typeKey: string, factorsIds: number[]) => {
    return factorsIds
      .map(factorId => {
        return this.factorService.getFactorLabel(typeKey, factorId);
      })
      .join(", ");
  };

  get positionName() {
    return this.issueForm.get("positionName");
  }

  get name() {
    return this.issueForm.get("name");
  }

  get nameValue() {
    return this.issueForm.get("name").value;
  }

  get surname() {
    return this.issueForm.get("surname");
  }

  get surnameValue() {
    return this.issueForm.get("surname").value;
  }

  get peselNumber() {
    return this.issueForm.get("peselNumber");
  }

  get certificateType() {
    return this.issueForm.get("certificateType");
  }

  get sexType() {
    return this.issueForm.get("sexType");
  }

  get street() {
    return this.issueForm.get("street");
  }

  get houseNumber() {
    return this.issueForm.get("houseNumber");
  }

  get city() {
    return this.issueForm.get("city");
  }
}
