namespace dotnet_graphql_todoapp;

public class TodoMutation
{
  private readonly TodoDb _context;

  public TodoMutation(TodoDb context)
  {
      _context = context;
  }

  public async Task<Todo> AddTodoAsync(string title)
  {
      var todo = new Todo { Title = title, Completed = false };
      _context.Todos.Add(todo);
      await _context.SaveChangesAsync();
      return todo;
  }
}
