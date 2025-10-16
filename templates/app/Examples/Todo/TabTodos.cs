using SideScroll;
using SideScroll.Attributes;
using SideScroll.Avalonia.Controls;
using SideScroll.Resources;
using SideScroll.Serialize;
using SideScroll.Serialize.DataRepos;
using SideScroll.Tabs;
using SideScroll.Tabs.Toolbar;

namespace SideScrollAppTemplate.Examples.Todo;

public class TabTodos : ITab
{
	public TabInstance Create() => new Instance();

	public class Toolbar : TabToolbar
	{
		public ToolButton ButtonRefresh { get; set; } = new("Refresh", Icons.Svg.Refresh);

		[Separator]
		public ToolButton ButtonNew { get; set; } = new("New", Icons.Svg.BlankDocument);
		public ToolButton ButtonSave { get; set; } = new("Save", Icons.Svg.Save, isDefault: true);

		[Separator]
		public ToolButton ButtonDelete { get; set; } = new("Delete", Icons.Svg.Delete);

		[Separator]
		public ToolButton ButtonCopyToClipboard { get; set; } = new("Copy to Clipboard", Icons.Svg.Copy);

		[Separator]
		public ToolButton ButtonReset { get; set; } = new("Reset", Icons.Svg.Reset);
	}

	public class Instance : TabInstance
	{
		private const string GroupId = "Todo";

		private DataRepoView<TodoItem>? _dataRepoView;
		private TodoItem? _todoItem;
		private TabFormObject? _formObject;

		private readonly TodoItem[] _defaultSamples =
		[
			new()
			{
				Id = 1,
				Title = "Refuel astronaut (snack break)",
				Description = "Consume one pouch of space pudding and pretend it's crème brûlée. Hydrate like a champion.",
				Priority = TodoPriority.High,
				Status = TodoStatus.Completed,
			},
			new()
			{
				Id = 2,
				Title = "Moonwalk lap around the lander",
				Description = "Bounce gracefully in 1/6 g. Avoid dramatic slow-motion faceplants.",
				Priority = TodoPriority.Medium,
				Status = TodoStatus.InProgress,
			},
			new()
			{
				Id = 3,
				Title = "De-dust lunar boots",
				Description = "Brush off clingy lunar regolith; it's the glitter of space. Apologize to the air filter.",
				Priority = TodoPriority.Low,
			},
		];

		public Instance()
		{
			OnSelectionChanged += Instance_OnSelectionChanged;
		}

		public override void LoadUI(Call call, TabModel model)
		{
			model.MaxDesiredWidth = 850;

			_todoItem = new();
			_formObject = model.AddForm(_todoItem);

			Toolbar toolbar = new();
			toolbar.ButtonRefresh.Action = Refresh;
			toolbar.ButtonNew.Action = New;
			toolbar.ButtonSave.Action = Save;
			toolbar.ButtonDelete.Action = Delete;
			toolbar.ButtonCopyToClipboard.Action = CopyClipBoardUI;
			toolbar.ButtonReset.Action = Reset;
			model.AddObject(toolbar);

			LoadSavedItems(call, model);

			_todoItem.Id = _dataRepoView!.Items.Count + 1;
		}

		private void Instance_OnSelectionChanged(object? sender, ItemSelectedEventArgs e)
		{
			if (_formObject == null) return;

			if (e.Object is TodoItem todoItem)
			{
				_todoItem = todoItem.DeepClone();
				_formObject.Update(sender, _todoItem!);
			}
		}

		private void LoadSavedItems(Call call, TabModel model)
		{
			_dataRepoView = Data.App.LoadIndexedView<TodoItem>(call, GroupId);
			DataRepoInstance = _dataRepoView; // Allow links to pass the selected items

			if (_dataRepoView.Items.Count == 0)
			{
				_dataRepoView.Save(call, _defaultSamples);
			}

			var dataCollection = new DataViewCollection<TodoItem>(_dataRepoView);
			model.Items = dataCollection.Items;
		}

		private void Reset(Call call)
		{
			_dataRepoView!.DeleteAll(call);
			Reload();
		}

		private void Refresh(Call call)
		{
			Reload();
		}

		private void New(Call call)
		{
			_todoItem = new()
			{
				Id = _dataRepoView!.Items.Count + 1
			};
			_formObject!.Update(this, _todoItem);
			_formObject!.Focus(this);
		}

		private void Save(Call call)
		{
			Validate();

			var clone = _todoItem!.DeepClone();

			_dataRepoView!.Save(call, clone);
		}

		private void Delete(Call call)
		{
			foreach (TodoItem item in SelectedItems!)
			{
				_dataRepoView!.Delete(call, item);
			}
		}

		private void CopyClipBoardUI(Call call)
		{
			CopyToClipboard(SelectedItems);
		}
	}
}
