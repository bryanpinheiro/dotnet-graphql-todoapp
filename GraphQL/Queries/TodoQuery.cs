namespace dotnet_graphql_todoapp;

public class TodoQuery
{
  private readonly TodoDb _context;

  public TodoQuery(TodoDb context)
  {
    _context = context;
  }

  public IQueryable<Todo> GetTodos()
  {
    return _context.Todos;
  }
}
