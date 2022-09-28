
using ToDoClient.Services;

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
            client.BaseAddress = new Uri("https://user9f9bd262219b696.app.vtxhub.com/");
        });
        builder.Services.AddSingleton(Connectivity.Current);

        builder.Services.AddSingleton<IToDoService, ToDoService>();
		builder.Services.AddTransient<MainPage>();

		return builder.Build();
	}
}
