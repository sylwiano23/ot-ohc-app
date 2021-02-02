import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { FormBuilder, Validators, FormControl } from "@angular/forms";

import { finalize } from "rxjs/operators";

import { AuthService } from "@app/modules/auth/services/service";
import { UserSessionService } from "@app/modules/user/services/user-session.service";
import { ICredentials } from "../interfaces/credentials.interface";
import { FactorService } from "@app/modules/factor/services/service";

/**
 * Component for display auth screen
 */
@Component({
  selector: "login-form",
  templateUrl: "login.component.html"
})
export class LoginFormComponent {
  //region Properties

  auth: {
    login: string;
    password: string;
  } = {
    login: "",
    password: ""
  };
  authForm: any | ICredentials = this.formBuilder.group({
    login: new FormControl(this.auth.login, [Validators.required]),
    password: new FormControl(this.auth.password, [Validators.required])
  });

  busy = {
    action: false
  };

  //endregion

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private factorService: FactorService,
    private userSessionService: UserSessionService
  ) {}

  onLogin(formData: ICredentials) {
    this.busy.action = true;
    this.authService
      .login(formData)
      .pipe(finalize(() => (this.busy.action = false)))
      .subscribe(
        response => {
          console.log(response);
          let tokenDecoded = JSON.parse(atob(response.token.split(".")[1]));
          console.log(tokenDecoded);
          this.userSessionService.createData(response.token, tokenDecoded);

          this.factorService.loadAllFactors();
          this.router.navigateByUrl("/position");
        },
        error => {
          console.log(error);
        }
      );
  }

  onSubmit(formData: ICredentials) {
    return this.onLogin(formData);
  }

  get login() {
    return this.authForm.get("login");
  }

  get password() {
    return this.authForm.get("password");
  }
}
