namespace dotnet_graphql_todoapp;


using System.ComponentModel.DataAnnotations;

public record UpdateTodoInput(
  string? Title,
  [Required] bool Completed
);
