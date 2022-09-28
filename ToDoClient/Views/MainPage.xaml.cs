using System.Diagnostics;
using ToDoClient.Models;
using ToDoClient.Services;

namespace ToDoClient.Views;

public partial class MainPage : ContentPage
{
	private readonly IToDoService _toDoService;

	public MainPage(IToDoService toDoService)
	{
		InitializeComponent();
		_toDoService = toDoService;
		OnAppearing();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		collectionView.ItemsSource = await _toDoService.GetToDosAsync();
	}

	private async void OnAddToDo_Clicked(object sender, EventArgs e)
	{
		Debug.WriteLine(message: "Add Button Clicked");

		var navigationParameter = new Dictionary<string, object>
		{
			{ nameof(ToDo), new ToDo() },
		};

		await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigationParameter);
    }

	private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        Debug.WriteLine(message: "Item Changed Clicked.");

        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(ToDo), e.CurrentSelection.FirstOrDefault() as ToDo },
        };

        await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigationParameter);
    }
}

