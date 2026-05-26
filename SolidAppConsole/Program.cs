using SolidAppConsole.Services;


var registry = new PrincipleRegistry();
var menuService = new MenuService(registry);

menuService.Run();
