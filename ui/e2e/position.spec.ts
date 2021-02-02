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

//   it("should display positions list page", async function() {
//     const text = await browser.getText("app-home h1");
//     expect(text).to.equal("Stanowiska");
//   });

//   it("should open position form", async function() {
//     const text = await browser.getText("app-home h1");
//     expect(text).to.equal("Stanowiska");
//   });

//   it("should fill position form", async function() {
//     return browser.setValue(nameInput, "Czynnik pyłowy");
//   });

//   it("should submit position form", async function() {
//     return browser.click(submitButton).waitUntilTextExists("h1", "Stanowiska");
//   });

//   it("should display positions list page with new added element", async function() {
//     const text = await browser.getText("app-home h1");
//     expect(text).to.equal("Stanowiska");
//   });

//   it("should open edit position form", async function() {
//     return browser.click(editButton).waitUntilTextExists("label", "Nazwa");
//   });

//   it("should submit edit position form", async function() {
//     return browser.click(submitButton).waitUntilTextExists("h1", "Stanowiska");
//   });

//   it("should click delete position button", async function() {
//     return browser.click(deleteButton).waitUntilTextExists("h1", "Stanowiska");
//   });
// });
