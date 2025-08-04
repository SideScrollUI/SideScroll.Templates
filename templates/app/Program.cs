using Avalonia;
using Avalonia.Data.Core.Plugins;
using SideScroll.Utilities;

namespace SideScrollAppTemplate;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
	public static int Main(string[] args)
	{
		AppBuilder builder = BuildAvaloniaApp();

		// Remove Default DataAnnotations Validators
		// These validators show before values are entered, which ends up showing too many initial warnings
		// https://docs.avaloniaui.net/docs/data-binding/data-validation
		// Add custom template?
		BindingPlugins.DataValidators.RemoveAt(0);

		try
		{
			return builder.StartWithClassicDesktopLifetime(args);
		}
		catch (Exception e)
		{
			var settings = MainWindow.Settings;
			LogUtils.Save(settings.ExceptionsPath, settings.Name!, e);
			return 1;
		}
	}

	// Avalonia configuration, don't remove; also used by visual designer.
	public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
