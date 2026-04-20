using Avalonia.Controls;

namespace SideScrollAppTemplate.Browser;

public class BrowserApp : App
{
	protected override Control CreateSingleView() => new BrowserMainView();
}
