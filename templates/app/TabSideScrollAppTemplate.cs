using SideScrollAppTemplate.Examples;
using SideScroll;
using SideScroll.Avalonia.Tabs;
using SideScroll.Tabs;
using SideScroll.Tabs.Bookmarks;
using SideScroll.Tabs.Lists;
using SideScroll.Tabs.Samples;
using SideScroll.Tabs.Samples.Demo;

namespace SideScrollAppTemplate;

public class TabSideScrollAppTemplate : ITab
{
    public TabInstance Create() => new Instance();

    public class Instance : TabInstance
    {
        public override void Load(Call call, TabModel model)
        {
            model.Items = new List<ListItem>()
            {
                new("Demo", new TabSampleDemo()),
                new("Samples", new TabSamples()),
				new("Examples", new TabExamples()),
				new("Links", new TabLinks()),
				new("Settings", new TabAvaloniaSettings<SideScrollAppTemplateUserSettings>()),
            };
        }
    }
}
