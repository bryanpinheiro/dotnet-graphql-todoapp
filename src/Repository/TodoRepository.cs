
namespace dotnet_graphql_todoapp;

using Microsoft.EntityFrameworkCore;

public class TodoRepository : ITodoRepository, IAsyncDisposable
{
  private readonly DatabaseContext _dbcontext;

  public TodoRepository(IDbContextFactory<DatabaseContext> dbContextFactory)
  {
    _dbcontext = dbContextFactory.CreateDbContext();
  }

  public async Task<List<Todo>> GetAll()
  {
    return await _dbcontext.Todos.ToListAsync();
  }

  public async Task<Todo> GetByID(long todoID)
  {
    Todo? todo = await _dbcontext.Todos.FindAsync(todoID) 
                ?? throw new TodoNotFoundException(todoID);
    
    return todo;
  }

  public async Task Insert(CreateTodoInput inputTodo)
  {
    var todo = new Todo()
    {
      Title = inputTodo.Title,
      Completed = false
    };
    
    await _dbcontext.Todos.AddAsync(todo);
    await _dbcontext.SaveChangesAsync();
  }

  public async Task Update(Todo todo)
  {
    _dbcontext.Entry(todo).State = EntityState.Modified;
    await _dbcontext.SaveChangesAsync();
  }

  public async Task Delete(long todoID)
  {
    Todo todo = await _dbcontext.Todos.FindAsync(todoID) 
                ?? throw new TodoNotFoundException(todoID);

    _dbcontext.Todos.Remove(todo);

    await _dbcontext.SaveChangesAsync();
  }

  public ValueTask DisposeAsync()
  {
    return _dbcontext.DisposeAsync();
  }
}
