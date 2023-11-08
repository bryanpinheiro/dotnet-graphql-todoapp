namespace dotnet_graphql_todoapp;

public class TodoMutation
{
  public async Task<bool> CreateTodo(CreateTodoInput createTodoInput, ITodoRepository todoRepository)
  {
    await todoRepository.Insert(createTodoInput);
    return true;
  }

  public async Task<bool> UpdateTodo(long todoID, UpdateTodoInput updateTodoInput, ITodoRepository todoRepository)
  {
    var todo = await todoRepository.GetByID(todoID) 
                ?? throw new TodoNotFoundException(todoID);

    if (updateTodoInput.Title is not null) 
    {
      todo.Title = updateTodoInput.Title;
    }

    todo.Completed = updateTodoInput.Completed;
    
    await todoRepository.Update(todo);
    return true;
  }

  public async Task<bool> DeleteTodo(long todoID, ITodoRepository todoRepository)
  {
    await todoRepository.Delete(todoID);
    return true;
  }
}
