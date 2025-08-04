using Avalonia.Controls;
using SideScroll.Tabs;
using SideScroll.Tabs.Settings;
using SideScroll.Avalonia.Charts.LiveCharts;
using SideScroll.Avalonia.Controls;
using SideScroll.Avalonia.ScreenCapture;

namespace SideScrollAppTemplate;

public partial class MainWindow : BaseWindow
{
	public MainWindow() : base(Project.Load<CustomUserSettings>(Settings))
	{
		AddTab(new TabSample());

		LiveChartCreator.Register();
		ScreenCapture.AddControlTo(TabViewer);
		TabViewer.Toolbar?.AddVersion();

		Icon = new WindowIcon(Assets.Icons.SideScroll.Stream);
	}

	public static ProjectSettings Settings => new()
	{
		Name = "SideScrollAppTemplate",
		LinkType = "SideScrollAppTemplate",
		Version = new Version(0, 1),
		DataVersion = new Version(0, 1),
	};
}
