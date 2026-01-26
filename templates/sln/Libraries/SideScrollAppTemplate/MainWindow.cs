using Avalonia.Controls;
using SideScroll.Tabs;
using SideScroll.Avalonia.Charts.LiveCharts;
using SideScroll.Avalonia.Controls;
using SideScroll.Avalonia.Controls.ScreenCapture;

namespace SideScrollAppTemplate;

public class MainWindow : BaseWindow
{
	public MainWindow() : base(Project.Load<SideScrollAppTemplateUserSettings>(AppSettings.ProjectSettings))
	{
		LoadTab(new TabSideScrollAppTemplate());

		LiveChartCreator.Register();
		ScreenCapture.AddControlTo(TabViewer);
		TabViewer.Toolbar?.AddRightControls();

		Icon = new WindowIcon(Assets.Icons.SideScroll.Stream);
	}
}
