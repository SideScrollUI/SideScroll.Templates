using Avalonia.Controls;
using SideScroll.Tabs;
using SideScroll.Avalonia.Charts.LiveCharts;
using SideScroll.Avalonia.Controls;
using SideScroll.Avalonia.Controls.ScreenCapture;

namespace SideScrollAppTemplate;

public class MainWindow : BaseWindow
{
	public MainWindow() : base(Project.Load<SideScrollAppTemplateUserSettings>(SideScrollAppTemplateProjectSettings.Default))
	{
		Icon = new WindowIcon(Assets.Icons.SideScroll.Stream);

		LiveChartCreator.Register();
		ScreenCapture.AddControlTo(TabViewer);
		TabViewer.Toolbar?.AddRightControls();
		
		LoadTab(new TabSideScrollAppTemplate());
	}
}
