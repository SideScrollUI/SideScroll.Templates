using Avalonia;
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

		try
		{
			return builder.StartWithClassicDesktopLifetime(args);
		}
		catch (Exception e)
		{
			var settings = AppSettings.ProjectSettings;
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
