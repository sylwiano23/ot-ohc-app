import { app, BrowserWindow, screen, Menu, dialog } from "electron";
import * as path from "path";
import * as url from "url";

let win, serve;
const args = process.argv.slice(1);
serve = args.some(val => val === "--serve");

function createWindow() {
  const electronScreen = screen;
  const size = electronScreen.getPrimaryDisplay().workAreaSize;

  // Create the browser window.
  win = new BrowserWindow({
    x: 0,
    y: 0,
    width: size.width,
    height: size.height,
    webPreferences: {
      nodeIntegration: true
    }
  });

  const template = [
    {
      label: "Plik",
      submenu: [{ role: "quit" }]
    },
    {
      label: "Edycja",
      submenu: [
        { role: "undo" },
        { role: "redo" },
        { type: "separator" },
        { role: "cut" },
        { role: "copy" },
        { role: "paste" }
      ]
    },
    {
      label: "Okno",
      submenu: [{ role: "minimize" }, { role: "zoom" }, { role: "close" }]
    }
  ];

  const menu = (Menu as any).buildFromTemplate(template);
  Menu.setApplicationMenu(menu);

  if (serve) {
    require("electron-reload")(__dirname, {
      electron: require(`${__dirname}/node_modules/electron`)
    });
    win.loadURL("http://localhost:4200");
  } else {
    win.loadURL(
      url.format({
        pathname: path.join(__dirname, "dist/index.html"),
        protocol: "file:",
        slashes: true
      })
    );
  }

  if (serve) {
    win.webContents.openDevTools();
  }

  // Emitted when the window is being closed.
  win.on("close", async function(event) {
    event.preventDefault();
    try {
      let choice = await dialog.showMessageBox(this, {
        type: "question",
        buttons: ["Tak", "Nie"],
        cancelId: 1,
        title: "Potwierdzenie",
        message: "Czy na pewno zamknąć aplikację?"
      });
      console.log(choice);
      if (choice && choice.response === 1) {
        event.preventDefault();
        event.defaultPrevented = false;
      }
      if (choice && choice.response === 0) {
        event.defaultPrevented = false;
        app.exit(0);
      }
    } catch (err) {
      app.exit(0);
    }
  });

  // Emitted when the window is closed.
  win.on("closed", () => {
    // Dereference the window object, usually you would store window
    // in an array if your app supports multi windows, this is the time
    // when you should delete the corresponding element.
    win = null;
  });
}

try {
  // This method will be called when Electron has finished
  // initialization and is ready to create browser windows.
  // Some APIs can only be used after this event occurs.
  app.on("ready", createWindow);

  // Quit when all windows are closed.
  app.on("window-all-closed", () => {
    // On OS X it is common for applications and their menu bar
    // to stay active until the user quits explicitly with Cmd + Q
    if (process.platform !== "darwin") {
      app.quit();
    }
  });

  app.on("activate", () => {
    // On OS X it's common to re-create a window in the app when the
    // dock icon is clicked and there are no other windows open.
    if (win === null) {
      createWindow();
    }
  });
} catch (e) {
  // Catch Error
  // throw e;
}
