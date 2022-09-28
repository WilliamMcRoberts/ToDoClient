using ToDoClient.Models;
using ToDoClient.Services;

namespace ToDoClient;

public partial class MainPage : ContentPage
{
	private readonly IToDoService _toDoService;

	public MainPage(IToDoService toDoService)
	{
		InitializeComponent();
		_toDoService = toDoService;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		collectionView.ItemSource = _toDoService.GetToDosAsync();
	}
}

