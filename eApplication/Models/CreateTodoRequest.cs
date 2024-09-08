namespace eApplication.Models;

public sealed record CreateTodoRequest(
    string Title,
    string Description);