using ToDoClient.Views;

namespace ToDoClient;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ManageToDoPage), typeof(ManageToDoPage));
    }
}
