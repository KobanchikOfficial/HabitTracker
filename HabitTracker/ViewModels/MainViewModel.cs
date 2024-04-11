using System.Collections.ObjectModel;
using ReactiveUI;
using System.Linq;
using Avalonia;
using System.Collections.Generic;
using System;

namespace HabitTracker.ViewModels
{
	public class MainViewModel : ViewModelBase
	{

		private string _textInput = "";

		private string dayOfWeek = "";

		private List<List<bool>> _matrix = new List<List<bool>>();


		public IReactiveCommand AddHabitCommand { get; }
		public IReactiveCommand AddDayCommand { get; }

		public ObservableCollection<TaskItem> AddHabit { get; } = new ObservableCollection<TaskItem>();
		public ObservableCollection<TaskItem> AddDay { get; } = new ObservableCollection<TaskItem>();

		public string TextInput
		{
			get => _textInput;
			set => this.RaiseAndSetIfChanged(ref _textInput, value);
		}

		public List<List<bool>> Matrix
		{
			get => _matrix;
			set => this.RaiseAndSetIfChanged(ref _matrix, value);
		}

		public MainViewModel()
		{
			AddHabitCommand = ReactiveCommand.Create(() => AddHabits());
			AddDayCommand = ReactiveCommand.Create(() => AddDays());
		}


		private void AddHabits()
		{
			AddHabit.Add(new TaskItem(TextInput, true));
			TextInput = "";

			UpdateMatrix();
		}

		private void AddDays()
		{
			switch (dayOfWeek)
			{
				case "Пн": dayOfWeek = "Вт"; break;
				case "Вт": dayOfWeek = "Ср"; break;
				case "Ср": dayOfWeek = "Чт"; break;
				case "Чт": dayOfWeek = "Пт"; break;
				case "Пт": dayOfWeek = "Сб"; break;
				case "Сб": dayOfWeek = "Вс"; break;
				case "Вс": dayOfWeek = "Пн"; break;
				default: dayOfWeek = "Пн"; break;
			}

			AddDay.Add(new TaskItem(dayOfWeek, false));
			TextInput = "";

			UpdateMatrix();
		}

		public void UpdateMatrix()
		{
			// Определение размеров матрицы по количеству элементов в AddHabit и AddDay
			int habitCount = AddHabit.Count;
			int dayCount = AddDay.Count;

			// Создание новой матрицы
			List<List<bool>> newMatrix = new List<List<bool>>();

			// Заполнение матрицы значениями по умолчанию
			for (int i = 0; i < habitCount; i++)
			{
				List<bool> column = new List<bool>();
				for (int j = 0; j < dayCount; j++)
				{
					column.Add(false);
				}
				newMatrix.Add(column);
			}

			// Обновление матрицы
			Matrix = newMatrix;
		}

	}
}
