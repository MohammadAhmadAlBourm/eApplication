using eApplication.Entities;

namespace eApplication.Models;

public sealed record UpdateTodoRequest(
    int Id,
    string Title,
    string Description,
    TodoStatus Status);