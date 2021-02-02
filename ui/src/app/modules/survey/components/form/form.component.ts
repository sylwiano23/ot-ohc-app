import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { FormBuilder, Validators, FormControl } from "@angular/forms";

import { ToastrService } from "ngx-toastr";

import { finalize } from "rxjs/operators";
import * as moment from "moment";

import { SurveyService } from "@app/modules/survey/services/service";
import { PositionService } from "@app/modules/position/services/service";
import {
  Survey,
  ISurveyForm,
  SURVEY_TYPES_NAMES,
  SURVEY_TYPES_PROPERTIES,
  SURVEY_TYPES_PROPERTIES_TRANSLATIONS
} from "@app/modules/survey/interfaces/survey";

/**
 * Component for display survey screen
 */
@Component({
  selector: "survey-form",
  templateUrl: "form.component.html"
})
export class SurveyFormComponent {
  //region Properties

  surveyId: number;
  typeKey: string;

  survey: Survey = new Survey();
  surveyForm: any | ISurveyForm;

  positions: Position[] = [];

  surveyProperties: string[] = [];

  SURVEY_TYPES_NAMES: { [key: string]: string } = SURVEY_TYPES_NAMES;
  SURVEY_TYPES_PROPERTIES: { [key: string]: string[] } = SURVEY_TYPES_PROPERTIES;
  SURVEY_TYPES_PROPERTIES_TRANSLATIONS: { [key: string]: string } = SURVEY_TYPES_PROPERTIES_TRANSLATIONS;

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
    private surveyService: SurveyService,
    private positionService: PositionService
  ) {
    this.surveyId = Number(this.route.snapshot.params.id);
    this.typeKey = this.route.snapshot.queryParams.type_key;

    this.positionService.getPositions(() => {});

    this.positionService.currentPositions.subscribe((positions: any) => {
      this.positions = positions;
    });

    if (this.typeKey === "ElectromagneticField") {
      this.surveyProperties = SURVEY_TYPES_PROPERTIES[`ElectromagneticField_FORM`];
    } else {
      this.surveyProperties = SURVEY_TYPES_PROPERTIES[this.typeKey];
    }

    if (this.surveyId) {
      this.loadSurvey();
    } else {
      this.survey = new Survey();
      this.initializeForm();
      this.busy.load = false;
    }
  }

  loadSurvey() {
    this.busy.load = true;
    this.surveyService
      .get(this.surveyId)
      .pipe(finalize(() => (this.busy.load = false)))
      .subscribe(
        response => {
          this.survey = response;
          this.initializeForm();
        },
        error => {
          console.log(error);
        }
      );
  }

  create(formData: ISurveyForm) {
    if (formData.date) {
      formData.date = moment(formData.date).format("YYYY-MM-DD");
    }
    if (formData.nextSurveyDate) {
      formData.nextSurveyDate = moment(formData.nextSurveyDate).format("YYYY-MM-DD");
    }

    this.busy.action = true;
    this.surveyService
      .create(formData)
      .pipe(finalize(() => (this.busy.action = false)))
      .subscribe(
        response => {
          this.toastr.success("Zmiany zapisane.", "Sukces");

          this.router.navigate(["/survey"], { queryParams: { type_key: this.typeKey } });
        },
        error => {
          console.log(error);
        }
      );
  }

  update(formData: ISurveyForm) {
    if (formData.date) {
      formData.date = moment(formData.date).format("YYYY-MM-DD");
    }
    if (formData.nextSurveyDate) {
      formData.nextSurveyDate = moment(formData.nextSurveyDate).format("YYYY-MM-DD");
    }

    this.busy.action = true;
    this.surveyService
      .update({ id: this.surveyId, ...formData })
      .pipe(finalize(() => (this.busy.action = false)))
      .subscribe(
        response => {
          this.toastr.success("Zmiany zapisane.", "Sukces");

          this.router.navigate(["/survey"], { queryParams: { type_key: this.typeKey } });
        },
        error => {
          console.log(error);
        }
      );
  }

  initializeForm() {
    let group = {};

    for (let i = 0; i < this.surveyProperties.length; i++) {
      let propName = this.surveyProperties[i];
      group[propName] = new FormControl(this.survey[propName], Validators.required);

      if (propName === "isSurveySuspend" || propName === "nextSurveyDate" || propName === "isSurveyUsed" || propName === "isNormExceeded") {
        group[propName] = new FormControl(this.survey[propName]);
      }
    }

    if (this.typeKey === "ElectromagneticField") {
      group["intermediateZoneE"] = new FormControl(this.survey["intermediateZoneE"], Validators.required);
      group["intermediateZoneH"] = new FormControl(this.survey["intermediateZoneH"], Validators.required);

      group["riskZoneE"] = new FormControl(this.survey["riskZoneE"], Validators.required);
      group["riskZoneH"] = new FormControl(this.survey["riskZoneH"], Validators.required);

      group["dengerousZoneE"] = new FormControl(this.survey["dengerousZoneE"], Validators.required);
      group["dengerousZoneH"] = new FormControl(this.survey["dengerousZoneH"], Validators.required);
    }

    this.surveyForm = this.formBuilder.group({ ...group, factorType: this.typeKey });
  }

  onSubmit(formData: ISurveyForm) {
    return this.surveyId ? this.update(formData) : this.create(formData);
  }

  getFormField(propName: string) {
    return this.surveyForm.get(propName);
  }
}
