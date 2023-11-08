namespace dotnet_graphql_todoapp;


public class TodoQuery
{
  public Task<List<Todo>> GetTodos(ITodoRepository todoRepository)
  {
    return todoRepository.GetAll();
  }

  public Task<Todo> GetTodo(long todoId, ITodoRepository todoRepository)
  {
    return todoRepository.GetByID(todoId);
  }
}
