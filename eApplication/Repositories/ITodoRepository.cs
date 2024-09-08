using eApplication.Entities;

namespace eApplication.Repositories;

public interface ITodoRepository
{
    Task<bool> Create(Todo todo, CancellationToken cancellationToken);
    Task<bool> Update(Todo todo, CancellationToken cancellationToken);
    Task<bool> Delete(int id, CancellationToken cancellationToken);
    Task<Todo?> GetById(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Todo>> GetList(CancellationToken cancellationToken);

    IEnumerable<object> GetTodoStatuses(CancellationToken cancellation);
}