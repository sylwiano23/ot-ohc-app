import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";

import { IFactorForm } from "../interfaces/factor";

import { appConfig } from "@env/environment";

@Injectable()
export class FactorResource {
  // props

  private moduleUrl: string = `${appConfig.apiEndpoint}/Factors`;

  //endregion

  constructor(private http: HttpClient) {}

  //region Behaviors

  /**
   * @inheritDoc
   */
  public list(params: { factorType: string }): Observable<any> {
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
  public create(factor: IFactorForm): Observable<any> {
    return this.http.post(`${this.moduleUrl}`, factor);
  }

  /**
   * @inheritDoc
   */
  public update(factor: IFactorForm): Observable<any> {
    return this.http.put(`${this.moduleUrl}`, factor);
  }

  /**
   * @inheritDoc
   */
  public delete(id: number): Observable<any> {
    return this.http.delete(`${this.moduleUrl}/${id}`);
  }

  //endregion
}
