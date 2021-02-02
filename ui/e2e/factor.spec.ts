// import { expect } from "chai";
// import { SpectronClient } from "spectron";

// import commonSetup from "./common-setup";

// describe("ot-ohc-app App", function() {
//   commonSetup.apply(this);

//   let browser: any;
//   let client: SpectronClient;

//   const nameInput = "form input[formControlName='name']";
//   const submitButton = "button*=Zapisz";
//   const editButton = "button*=Edytuj";
//   const deleteButton = "button*=Usuń";

//   beforeEach(function() {
//     client = this.app.client;
//     browser = client as any;
//   });

//   it("creates initial windows", async function() {
//     const count = await client.getWindowCount();
//     expect(count).to.equal(1);
//   });

//   it("should display factors list page", async function() {
//     const text = await browser.getText("app-home h1");
//     expect(text).to.equal("Czynniki");
//   });

//   it("should open factor form", async function() {
//     const text = await browser.getText("app-home h1");
//     expect(text).to.equal("Czynniki");
//   });

//   it("should fill factor form", async function() {
//     return browser.setValue(nameInput, "Czynnik pyłowy");
//   });

//   it("should submit factor form", async function() {
//     return browser.click(submitButton).waitUntilTextExists("h1", "Czynniki");
//   });

//   it("should display factors list page with new added element", async function() {
//     const text = await browser.getText("app-home h1");
//     expect(text).to.equal("Czynniki");
//   });

//   it("should open edit factor form", async function() {
//     return browser.click(editButton).waitUntilTextExists("label", "Nazwa");
//   });

//   it("should submit edit factor form", async function() {
//     return browser.click(submitButton).waitUntilTextExists("h1", "Czynniki");
//   });

//   it("should click delete factor button", async function() {
//     return browser.click(deleteButton).waitUntilTextExists("h1", "Czynniki");
//   });
// });
