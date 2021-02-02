// import { expect } from "chai";
// import { SpectronClient } from "spectron";

// import commonSetup from "./common-setup";

// describe("ot-ohc-app App", function() {
//   commonSetup.apply(this);

//   let client: SpectronClient;

//   const nameInput = "form input[formControlName='name']";
//   const printButton = "button*=Drukuj";

//   beforeEach(function() {
//     client = this.app.client;
//   });

//   it("creates initial windows", async function() {
//     const count = await client.getWindowCount();
//     expect(count).to.equal(1);
//   });

//   it("should display positions list page", async function() {
//     const text = await client.getText("app-home h1");
//     expect(text).to.equal("Stanowiska");
//   });

//   it("should open position issue form", async function() {
//     const text = await client.getText("app-home h1");
//     expect(text).to.equal("Stanowiska");
//   });

//   it("should fill position issue form", async function() {
//     return client.setValue(nameInput, "Czynnik pyłowy");
//   });

//   it("should submit position issue form", async function() {
//     return client.click(printButton).waitUntilTextExists("ngx-extended-pdf-viewer");
//   });
// });
