
using eApplication.Repositories;

namespace eApplication.Endpoints.TodoEndpoints;

public class GetTodoById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/todos/{id}", async (int id, ITodoRepository todoRepository, CancellationToken cancellationToken) =>
        {
            var todo = await todoRepository.GetById(id, cancellationToken);

            return todo is not null ? Results.Ok(todo) : Results.NotFound();
        });
    }
}
