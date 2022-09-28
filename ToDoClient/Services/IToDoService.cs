

using ToDoClient.Models;

namespace ToDoClient.Services;

public interface IToDoService
{
    Task<List<ToDo>> GetToDosAsync();

    Task UpdateToDoAsync(ToDo todo);

    Task AddToDoAsync(ToDo todo);

    Task DeleteToDoAsync(int id);
}
