import { expect } from "chai";
import { SpectronClient } from "spectron";

import commonSetup from "./common-setup";
import { passwords } from "./passwords";

describe("ot-ohc-app App", function() {
  commonSetup.apply(this);

  let client: SpectronClient;
  let browser: any;

  const loginInput = "form input[formControlName='login']";
  const passwordInput = "form input[formControlName='password']";
  const submitButton = "button*=Zaloguj";

  beforeEach(function() {
    client = this.app.client;
    browser = client as any;
  });

  // it("creates initial windows", async function() {
  //   const count = await client.getWindowCount();
  //   expect(count).to.equal(1);
  // });

  // it("should display message saying App works !", async function() {
  //   const text = await browser.getText("app-home h1");
  //   expect(text).to.equal("Zaświadczenia");
  // });

  it("Fill login form", async function() {
    const text = await browser
      .setValue(loginInput, passwords.login)
      .setValue(passwordInput, passwords.password)
      .click(submitButton)
      .waitUntilTextExists("#title", "Stanowiska:")
      .getText("#title");
    expect(text).to.equal("Stanowiska:");
  });
});
