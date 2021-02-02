import { Component, HostListener } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";

import { ElectronService } from "./core/services";
import { appConfig } from "../environments/environment";

import "../assets/styles/styles.scss";

import { FactorService } from "./modules/factor/services/service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent {
  constructor(public electronService: ElectronService, private translate: TranslateService) {
    translate.setDefaultLang("pl");

    console.log("appConfig", appConfig);

    if (electronService.isElectron) {
      console.log(process.env);
      console.log("Mode electron");
      console.log("Electron ipcRenderer", electronService.ipcRenderer);
      console.log("NodeJS childProcess", electronService.childProcess);
    } else {
      console.log("Mode web");
    }
  }
}
