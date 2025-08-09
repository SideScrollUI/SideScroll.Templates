using SideScrollAppTemplate.Examples.Todo;
using SideScroll;
using SideScroll.Tabs;
using SideScroll.Tabs.Lists;

namespace SideScrollAppTemplate.Examples;

public class TabExamples : ITab
{
    public TabInstance Create() => new Instance();

    public class Instance : TabInstance
    {
        public override void Load(Call call, TabModel model)
        {
            model.Items = new List<ListItem>()
            {
                new("Todo", new TabTodos()),
            };
        }
    }
}
