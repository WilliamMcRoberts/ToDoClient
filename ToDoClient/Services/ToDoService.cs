

using System.Net.Http.Json;
using ToDoClient.Models;
using Newtonsoft.Json;
using Android.OS;

namespace ToDoClient.Services;

public class ToDoService : IToDoService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConnectivity _connectivity;

    public ToDoService(IHttpClientFactory httpClientFactory, IConnectivity connectivity)
    {
        _httpClientFactory = httpClientFactory;
        _connectivity = connectivity;
    }

    public async Task AddToDoAsync(ToDo todo)
    {
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("No connectivity!",
                $"Please check internet and try again.", "OK");
            return;
        }

        try
        {
            var client = _httpClientFactory.CreateClient("todos");

            string json = JsonConvert.SerializeObject(todo);

            var httpContent =
                new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            await client.PostAsync($"api/todo", httpContent);
        }

        catch (Exception ex)
        {

            await Shell.Current.DisplayAlert(
                "Failed To Create To Do Item.", ex.Message, "OK");
        }
        
    }

    public async Task DeleteToDoAsync(int id)
    {
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("No connectivity!",
                $"Please check internet and try again.", "OK");
            return;
        }

        try
        {
            var client = _httpClientFactory.CreateClient("todos");

            await client.DeleteAsync($"api/todo/{id}");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert(
                "Failed To Delete To Do Item.", ex.Message, "OK");
        }
    }

    public async Task<List<ToDo>> GetToDosAsync()
    {
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("No connectivity!",
                $"Please check internet and try again.", "OK");
            return new List<ToDo>();
        }

        var todos = new List<ToDo>();
        try
        {
            var client = _httpClientFactory.CreateClient("todos");

            todos = await client.GetFromJsonAsync<List<ToDo>>($"api/todo");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert(
                "Failed To Get To Do List.", ex.Message, "OK");
        }

        return todos;
    }

    public async Task UpdateToDoAsync(ToDo todo)
    {
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("No connectivity!",
                $"Please check internet and try again.", "OK");
            return;
        }

        try
        {
            var client = _httpClientFactory.CreateClient("todos");

            string json = JsonConvert.SerializeObject(todo);

            var httpContent =
                new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            await client.PutAsync($"api/todo/{todo.Id}", httpContent);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert(
                "Failed To Update To Do Item.", ex.Message, "OK");
        }
    }
}
