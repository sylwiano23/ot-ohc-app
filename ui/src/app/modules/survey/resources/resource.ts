import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";

import { ISurveyForm } from "../interfaces/survey";

import { appConfig } from "@env/environment";

@Injectable()
export class SurveyResource {
  // props

  private moduleUrl: string = `${appConfig.apiEndpoint}/Surveys`;

  //endregion

  constructor(private http: HttpClient) {}

  //region Behaviors

  /**
   * @inheritDoc
   */
  public list(params: { factorType: string; sort: string; sortDirection: "DESC" | "ASC" }): Observable<any> {
    return this.http.get(`${this.moduleUrl}`, {
      params
    });
  }

  /**
   * @inheritDoc
   */
  public get(id: number): Observable<any> {
    return this.http.get(`${this.moduleUrl}/getById/${id}`);
  }

  /**
   * @inheritDoc
   */
  public create(survey: ISurveyForm): Observable<any> {
    return this.http.post(`${this.moduleUrl}`, survey);
  }

  /**
   * @inheritDoc
   */
  public update(survey: ISurveyForm): Observable<any> {
    return this.http.put(`${this.moduleUrl}`, survey);
  }

  /**
   * @inheritDoc
   */
  public delete(id: number): Observable<any> {
    return this.http.delete(`${this.moduleUrl}/${id}`);
  }

  //endregion
}
