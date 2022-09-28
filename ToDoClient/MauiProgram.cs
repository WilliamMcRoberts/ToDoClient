
using ToDoClient.Services;
using ToDoClient.Views;

namespace ToDoClient;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddHttpClient("todos", client =>
        {
			client.BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ?
					new Uri("https://user9f9bd262219b696.app.vtxhub.com/")
					: new Uri("https://localhost:7254/");
        });

        builder.Services.AddSingleton(Connectivity.Current);

        builder.Services.AddSingleton<IToDoService, ToDoService>();

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<ManageToDoPage>();

		return builder.Build();
	}
}
