using eApplication.Repositories;

namespace eApplication.Endpoints.TodoEndpoints;

public class DeleteTodo : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/todos/{id}", async (
            int id,
            ITodoRepository todoRepository,
            CancellationToken cancellationToken) =>
        {
            var response = await todoRepository.Delete(id, cancellationToken);
            return Results.Ok(response);
        });
    }
}