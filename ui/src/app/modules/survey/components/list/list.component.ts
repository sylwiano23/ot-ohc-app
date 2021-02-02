import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

import { remote } from "electron";

const dialogOptions = { type: "info", buttons: ["Tak", "Nie"], cancelId: 1, message: "Czy na pewno chcesz usunąć?" };

import { ToastrService } from "ngx-toastr";

import { finalize } from "rxjs/operators";

import { SurveyService } from "@app/modules/survey/services/service";
import {
  Survey,
  SURVEY_TYPES_NAMES,
  SURVEY_TYPES_PROPERTIES,
  SURVEY_TYPES_PROPERTIES_TRANSLATIONS
} from "@app/modules/survey/interfaces/survey";
import { UserSessionService } from "@app/modules/user/services/user-session.service";

/**
 * Component for display survey screen
 */
@Component({
  selector: "survey-list",
  templateUrl: "list.component.html"
})
export class SurveyListComponent {
  //region Properties

  typeKey: string;

  surveys: Survey[] = [];

  sort: string = "date";

  surveyPropertiesListHeader: string[] = [];
  surveyPropertiesListBody: string[] = [];

  isAdmin: boolean = false;

  SURVEY_TYPES_NAMES: { [key: string]: string } = SURVEY_TYPES_NAMES;
  SURVEY_TYPES_PROPERTIES: { [key: string]: string[] } = SURVEY_TYPES_PROPERTIES;
  SURVEY_TYPES_PROPERTIES_TRANSLATIONS: { [key: string]: string } = SURVEY_TYPES_PROPERTIES_TRANSLATIONS;

  busy = {
    load: true
  };

  //endregion

  constructor(
    public userSessionService: UserSessionService,
    private surveyService: SurveyService,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) {
    this.route.queryParams.subscribe(queryParams => {
      let typeKey = queryParams["type_key"];

      this.typeKey = typeKey;

      if (this.typeKey === "ElectromagneticField") {
        this.surveyPropertiesListHeader = SURVEY_TYPES_PROPERTIES[`ElectromagneticField_LIST_HEADER`];
        this.surveyPropertiesListBody = SURVEY_TYPES_PROPERTIES[`ElectromagneticField_LIST_BODY`];
      } else {
        this.surveyPropertiesListHeader = SURVEY_TYPES_PROPERTIES[this.typeKey];
        this.surveyPropertiesListBody = SURVEY_TYPES_PROPERTIES[this.typeKey];
      }

      this.loadSurveys();
    });

    this.userSessionService.currentData.subscribe(data => {
      this.isAdmin = this.userSessionService.isAdmin;
    });
  }

  loadSurveys() {
    this.busy.load = true;
    this.surveyService
      .list(this.typeKey, this.sort)
      .pipe(finalize(() => (this.busy.load = false)))
      .subscribe(
        response => {
          this.surveys = response.surveys;
        },
        error => {
          console.log(error);
        }
      );
  }

  delete(surveyId: number) {
    remote.dialog.showMessageBox(remote.getCurrentWindow(), dialogOptions).then(({ response }) => {
      if (response === 0) {
        this.surveyService.delete(surveyId).subscribe(
          response => {
            this.toastr.success("Zmiany zapisane.", "Sukces");

            this.loadSurveys();
          },
          error => {
            console.log(error);
          }
        );
      }
    });
  }

  onSortChange(propName: string) {
    if (this.sort.replace("-", "") === propName) {
      if (this.sort.includes("-")) {
        this.sort = propName;
      } else {
        this.sort = `-${propName}`;
      }
    } else {
      this.sort = propName;
    }

    this.loadSurveys();
  }

  onIsSurveyUsedChange(value: boolean) {}

  trackById(index: number, item: Survey) {
    return item.id;
  }
}
