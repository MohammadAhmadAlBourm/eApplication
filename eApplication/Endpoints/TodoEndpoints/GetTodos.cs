
using eApplication.Repositories;

namespace eApplication.Endpoints.TodoEndpoints;

public class GetTodos : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/todos", async (ITodoRepository todoRepository, CancellationToken cancellationToken) =>
        {
            var todos = await todoRepository.GetList(cancellationToken);

            return Results.Ok(todos);
        });
    }
}