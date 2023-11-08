namespace dotnet_graphql_todoapp;

public class TodoNotFoundException : Exception
{
  public TodoNotFoundException(long todoId) : base($"To-Do with ID {todoId} not found.") { }
}
