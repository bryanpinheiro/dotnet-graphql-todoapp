namespace dotnet_graphql_todoapp;

public interface ITodoRepository
{
  Task<List<Todo>> GetAll();
  Task<Todo> GetByID(long todoID);
  Task Insert(CreateTodoInput todo);
  Task Update(Todo todo);
  Task Delete(long todoID);
}