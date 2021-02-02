import { EventEmitter, Injectable } from "@angular/core";
import { Router } from "@angular/router";

import { IUserModel } from "@app/modules/user/interfaces/user.interface";
import { BehaviorSubject } from "rxjs";
import { appConfig } from "@env/environment";

//region Constants
const SESSION_NAME = "user_session";

//endregion

@Injectable({ providedIn: "root" })
export class UserSessionService {
  //region Events

  //endregion

  //region Properties

  //endregion

  constructor() {
    if (!appConfig.production)
      this.data.next(
        localStorage.getItem(SESSION_NAME) ? JSON.parse(localStorage.getItem(SESSION_NAME)) : new UserSessionData()
      );
  }

  //region Accessors

  /**
   * Return user access token
   *
   * @returns {string}
   */
  get accessToken(): string {
    return this.data.getValue().accessToken;
  }

  /**
   * Return whether user has access token
   *
   * @returns {boolean}
   */
  get hasAccessToken(): boolean {
    return !!this.data.getValue().accessToken;
  }

  /**
   * Return user role
   *
   * @returns {string}
   */
  get role(): string {
    return this.data.getValue().user.role;
  }

  /**
   * Return if user is admin
   *
   * @returns {boolean}
   */
  get isAdmin(): boolean {
    return this.data.getValue().user.role === "Administrator";
  }

  //endregion

  //region Behaviors

  //region Config

  //endregion

  //region Data

  data = new BehaviorSubject<UserSessionData>(new UserSessionData());
  currentData = this.data.asObservable();

  /**
   * Create session data
   *
   * @param accessToken
   * @param user
   */
  public createData(accessToken: string, user: IUserModel) {
    this.data.next({
      accessToken: accessToken,
      user: user
    });

    if (!appConfig.production) localStorage.setItem(SESSION_NAME, JSON.stringify(this.data.getValue()));
  }

  /**
   * Destroy session data
   */
  public destroyData() {
    this.data.next(new UserSessionData());

    if (!appConfig.production) localStorage.removeItem(SESSION_NAME);
  }

  //endregion
}

class UserSessionData {
  public accessToken: string = null;
  public user: IUserModel = new IUserModel();
}
