
using eApplication.Entities;
using eApplication.Models;
using eApplication.Repositories;
using MapsterMapper;

namespace eApplication.Endpoints.TodoEndpoints;

public class UpdateTodo : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("api/todos", async (
            UpdateTodoRequest request,
            IMapper mapper,
            ITodoRepository todoRepository,
            CancellationToken cancellationToken) =>
        {
            var todo = mapper.Map<Todo>(request);
            var response = await todoRepository.Update(todo, cancellationToken);
            return Results.Ok(response);
        });
    }
}
