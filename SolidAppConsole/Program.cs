using SolidAppConsole.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var registry = new PrincipleRegistry();
var menuService = new MenuService(registry);

menuService.Run();
