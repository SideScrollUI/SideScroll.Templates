using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace SideScrollAppTemplate;

public partial class App : Application
{
	public override void Initialize()
	{
		AvaloniaXamlLoader.Load(this);
	}

	public override void OnFrameworkInitializationCompleted()
	{
		if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
		{
			desktop.MainWindow = new MainWindow();
		}
		else if (ApplicationLifetime is ISingleViewApplicationLifetime singleView)
		{
			singleView.MainView = CreateSingleView();
		}

		base.OnFrameworkInitializationCompleted();
	}

	protected virtual Control CreateSingleView() => throw new PlatformNotSupportedException();
}
