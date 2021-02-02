import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";

import { ICredentials } from "../interfaces/credentials.interface";

import { appConfig } from "@env/environment";

@Injectable()
export class AuthResource {
  //endregion

  constructor(private http: HttpClient) {}

  //region Behaviors

  /**
   * @inheritDoc
   */
  public login(credentials: ICredentials): Observable<any> {
    return this.http.post(`${appConfig.apiEndpoint}/Auth`, credentials);
  }

  //endregion
}
