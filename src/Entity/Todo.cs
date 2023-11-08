namespace dotnet_graphql_todoapp;

public class Todo
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public bool Completed { get; set; }
}
