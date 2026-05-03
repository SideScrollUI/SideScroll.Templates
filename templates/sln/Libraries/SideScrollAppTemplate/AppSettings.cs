using SideScroll.Attributes;
using SideScroll.Tabs.Settings;

namespace SideScrollAppTemplate;

public class SideScrollAppTemplateProjectSettings : ProjectSettings
{
	public override SideScrollAppTemplateUserSettings DefaultUserSettings => new()
	{
		EnableCustomTitleBar = DefaultEnableCustomTitlebar,
		DataSettings = new()
		{
			AppDataPath = DefaultAppDataPath,
			LocalDataPath = DefaultLocalDataPath,
		},
	};

	public static SideScrollAppTemplateProjectSettings Default => new()
	{
		Name = "SideScrollAppTemplate",
		LinkType = "SideScrollAppTemplate",
		Version = ProgramVersion(),
		DataVersion = new Version(0, 1),
	};
}

public class SideScrollAppTemplateUserSettings : UserSettings
{
	[Header("Custom"), WordWrap]
	public string ApiUri { get; set; } = @"http://localhost:80/";

	public int CustomLimit { get; set; } = 42;
}
