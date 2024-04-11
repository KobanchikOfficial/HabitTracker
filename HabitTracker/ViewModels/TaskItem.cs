using ReactiveUI;

namespace HabitTracker.ViewModels
{
	public class TaskItem : ReactiveObject
	{
		private string _taskText;
		public string TaskText
		{
			get => _taskText;
			set => this.RaiseAndSetIfChanged(ref _taskText, value);
		}

		public TaskItem(string taskText, bool isHabit)
		{
			if (taskText != null)
			{
				if (isHabit) TaskText = "Введите привычку...";
				else TaskText = taskText;
			}
			else
				TaskText = "default";
		}
	}
}
