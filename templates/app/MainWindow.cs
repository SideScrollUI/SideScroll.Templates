using Avalonia.Controls;
using SideScroll.Tabs;
using SideScroll.Avalonia.Charts.LiveCharts;
using SideScroll.Avalonia.Controls;
using SideScroll.Avalonia.ScreenCapture;

namespace SideScrollAppTemplate;

public partial class MainWindow : BaseWindow
{
	public MainWindow() : base(Project.Load<SideScrollAppTemplateUserSettings>(AppSettings.ProjectSettings))
	{
		AddTab(new TabSample());

		LiveChartCreator.Register();
		ScreenCapture.AddControlTo(TabViewer);
		TabViewer.Toolbar?.AddVersion();

		Icon = new WindowIcon(Assets.Icons.SideScroll.Stream);
	}
}
