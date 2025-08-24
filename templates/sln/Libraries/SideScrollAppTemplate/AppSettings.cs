using SideScroll.Attributes;
using SideScroll.Tabs.Settings;

namespace SideScrollAppTemplate;

public static class AppSettings
{
	public static ProjectSettings ProjectSettings => new()
	{
		Name = "SideScrollAppTemplate",
		LinkType = "SideScrollAppTemplate",
		Version = ProjectSettings.ProgramVersion(),
		DataVersion = new Version(0, 1),
	};
}

public class SideScrollAppTemplateUserSettings : UserSettings
{
	[Header("Custom"), WordWrap]
	public string ApiUri { get; set; } = @"http://localhost:80/";

	public int CustomLimit { get; set; } = 42;
}
