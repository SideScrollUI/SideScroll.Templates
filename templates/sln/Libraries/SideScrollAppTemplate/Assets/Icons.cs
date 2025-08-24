using SideScroll.Resources;
using System.Reflection;

namespace SideScrollAppTemplate.Assets;

public static class Icons
{
	public const string IconPath = "SideScrollAppTemplate.Assets";

	public static Assembly Assembly => Assembly.GetExecutingAssembly();

	public static ResourceView SideScroll => new(Assembly, IconPath, "Logo", "SideScroll", "ico");
}
