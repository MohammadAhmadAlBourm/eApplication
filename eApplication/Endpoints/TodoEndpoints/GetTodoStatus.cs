
using eApplication.Repositories;

namespace eApplication.Endpoints.TodoEndpoints;

public class GetTodoStatus : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/todos/status", (ITodoRepository todoRepository, CancellationToken cancellationToken) =>
        {
            var response = todoRepository.GetTodoStatuses(cancellationToken);
            return Results.Ok(response);
        });
    }
}