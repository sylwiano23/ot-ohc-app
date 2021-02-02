import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";

import { Position, IPositionForm, IIssueForm, PositionPayload } from "../interfaces/position.interface";

import { appConfig } from "@env/environment";

@Injectable()
export class PositionResource {
  // props

  private moduleUrl: string = `${appConfig.apiEndpoint}/Positions`;

  //endregion

  constructor(private http: HttpClient) {}

  //region Behaviors

  /**
   * @inheritDoc
   */
  public list(): Observable<any> {
    return this.http.get(`${this.moduleUrl}`);
  }

  /**
   * @inheritDoc
   */
  public get(id: number, params?: { with_values: string }): Observable<any> {
    return this.http.get(`${this.moduleUrl}/${id}`, {
      params
    });
  }

  /**
   * @inheritDoc
   */
  public create(position: PositionPayload): Observable<any> {
    return this.http.post(`${this.moduleUrl}`, position);
  }

  /**
   * @inheritDoc
   */
  public update(position: PositionPayload): Observable<any> {
    return this.http.put(`${this.moduleUrl}`, position);
  }

  /**
   * @inheritDoc
   */
  public delete(id: number): Observable<any> {
    return this.http.delete(`${this.moduleUrl}/${id}`);
  }

  /**
   * @inheritDoc
   */
  public issueCertificate(data: IIssueForm): Observable<any> {
    return this.http.post(`${appConfig.apiEndpoint}/Certifications`, data);
  }

  //endregion
}
