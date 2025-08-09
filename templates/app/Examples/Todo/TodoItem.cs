using SideScroll.Attributes;
using SideScroll.Extensions;
using SideScroll.Time;
using System.ComponentModel.DataAnnotations;

namespace SideScrollAppTemplate.Examples.Todo;

[Params, PublicData]
public class TodoItem
{
	[HiddenRow]
	public int Id { get; set; } = 1;

	[DataKey, Required, StringLength(100)]
	public string? Title { get; set; }

	[WordWrap]
	public string? Description { get; set; }

	public TodoPriority Priority { get; set; } = TodoPriority.Medium;

	public static string[] Statuses { get; } = TodoStatus.All;

	[BindList(nameof(Statuses)), ColumnIndex(2)]
	public string Status { get; set; }

	[HiddenRow]
	public DateTime Created { get; set; } = TimeZoneView.Now.Trim();

	public TodoItem()
	{
		Status = Statuses[0];
	}

	public override string? ToString() => Title;
}

public enum TodoPriority
{
	Low,
	Medium,
	High,
}

public class TodoStatus
{
	public const string New = "New";
	public const string InProgress = "In Progress";
	public const string Completed = "Completed";

	public static string[] All => [New, InProgress, Completed];
}
