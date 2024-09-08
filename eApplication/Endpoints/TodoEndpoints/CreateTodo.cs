
using eApplication.Entities;
using eApplication.Models;
using eApplication.Repositories;
using MapsterMapper;

namespace eApplication.Endpoints.TodoEndpoints;

public class CreateTodo : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/todos", async (
            CreateTodoRequest request,
            IMapper mapper,
            ITodoRepository todoRepository,
            CancellationToken cancellationToken) =>
        {
            var todo = mapper.Map<Todo>(request);
            var response = await todoRepository.Create(todo, cancellationToken);
            return Results.Ok(response);
        });
    }
}