using System.Diagnostics;
using ToDoClient.Models;
using ToDoClient.Services;

namespace ToDoClient.Views;

[QueryProperty(nameof(ToDo), "ToDo")]
public partial class ManageToDoPage : ContentPage
{
	private readonly IToDoService _toDoService;

	private bool _isNew;

	private ToDo _toDo;
	public ToDo ToDo
	{
		get => _toDo;

		set
		{
			_isNew = IsNew(value);
			_toDo = value;
			OnPropertyChanged();
		}
	}

	public ManageToDoPage(IToDoService toDoService)
	{
		InitializeComponent();
        BindingContext = this;
        _toDoService = toDoService;
	}

	private bool IsNew(ToDo toDo) => toDo.Id == 0;


    private async void OnSaveButton_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine(message: "Save Button Clicked");

		if (_isNew)
		{
            await _toDoService.AddToDoAsync(ToDo);
            await Shell.Current.GoToAsync("..");
			return;
        }

        await _toDoService.UpdateToDoAsync(ToDo);
        await Shell.Current.GoToAsync("..");
    }

    private async void OnDeleteButton_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine(message: "Delete Button Clicked");

		await _toDoService.DeleteToDoAsync(ToDo.Id);

        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelButton_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine(message: "Cancel Button Clicked");

		await Shell.Current.GoToAsync("..");
    }
}