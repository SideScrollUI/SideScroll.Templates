using Avalonia;
using Avalonia.Browser;

namespace SideScrollAppTemplate;

internal sealed class Program
{
	private static Task Main(string[] args) => BuildAvaloniaApp()
			.WithInterFont()
			.StartBrowserAppAsync("out");

	private static AppBuilder BuildAvaloniaApp()
		=> AppBuilder.Configure<App>();
}
