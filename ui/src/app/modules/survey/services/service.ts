import { Injectable } from "@angular/core";

import { BehaviorSubject } from "rxjs";

import { IResponseSuccess, IResponseError } from "@app/core/interfaces/response.interface";

import { SurveyResource } from "@app/modules/survey/resources/resource";
import { Survey, ISurveyForm, IHashSurveys } from "@app/modules/survey/interfaces/survey";

@Injectable()
export class SurveyService {
  //region Properties

  //endregion

  //region Events

  //endregion

  constructor(private surveyResource: SurveyResource) {}

  //region Accessors

  //endregion

  //region Behaviors

  /**
   * @inheritDoc
   */
  public list(typeKey: string, sort: string) {
    return this.surveyResource.list({
      factorType: typeKey,
      sort: sort.replace("-", ""),
      sortDirection: sort.includes("-") ? "DESC" : "ASC"
    });
  }

  /**
   * @inheritDoc
   */
  public get(id: number) {
    return this.surveyResource.get(id);
  }

  /**
   * @inheritDoc
   */
  public create(survey: ISurveyForm) {
    return this.surveyResource.create(survey);
  }

  /**
   * @inheritDoc
   */
  public update(survey: ISurveyForm) {
    return this.surveyResource.update(survey);
  }

  /**
   * @inheritDoc
   */
  public delete(id: number) {
    return this.surveyResource.delete(id);
  }

  //endregion
}
