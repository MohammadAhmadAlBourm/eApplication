using eApplication.Database;
using eApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace eApplication.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<TodoRepository> _logger;

    public TodoRepository(ApplicationDbContext context, ILogger<TodoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> Create(Todo todo, CancellationToken cancellationToken)
    {
        try
        {
            todo.CreatedDate = DateTime.Now;
            todo.Status = TodoStatus.InProgress;

            _context.Todos.Add(todo);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            var todo = await _context.Todos
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (todo is null)
            {
                return false;
            }

            _context.Todos.Remove(todo);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<Todo?> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Todos
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Todo>> GetList(CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Todos
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public IEnumerable<object> GetTodoStatuses(CancellationToken cancellation)
    {
        try
        {
            return Enum.GetValues(typeof(TodoStatus))
                       .Cast<TodoStatus>()
                       .Select(status => new
                       {
                           Id = (int)status,
                           Name = status.ToString()
                       })
                       .ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }

    public async Task<bool> Update(Todo todo, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _context.Todos
               .FirstOrDefaultAsync(x => x.Id == todo.Id, cancellationToken);

            if (entity is null)
            {
                return false;
            }

            entity.Title = todo.Title;
            entity.Description = todo.Description;
            entity.Status = todo.Status;
            entity.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Exception occurred {Message}", ex.Message);
            throw;
        }
    }
}