import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { appConfig } from "@env/environment";

@Injectable()
export class ErrorLogService {
  private lastError = null;

  constructor(private http: HttpClient) {}

  private sendErrorToServer(error: any) {
    return this.http
      .post(`${appConfig.apiEndpoint}/Log`, { message: error.stack.toString() })
      .subscribe((response: any) => {});
  }

  public logError(error: any) {
    if (appConfig.production && error) {
      if (this.lastError) {
        if (this.lastError === error.stack ? error.stack : error.toString()) return;
      }

      this.lastError = error.stack ? error.stack : error.toString();

      this.sendErrorToServer(error);
    } else {
      console.error(error);
    }
  }
}
