// See https://aka.ms/new-console-template for more information
using HMS.Context;
using HMS.Menu;

HMSDbContext dbContext = new HMSDbContext();

MainMenu mainMenu = new MainMenu(dbContext);

mainMenu.Menu();