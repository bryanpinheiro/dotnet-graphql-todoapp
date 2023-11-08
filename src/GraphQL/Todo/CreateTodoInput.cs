namespace dotnet_graphql_todoapp;


using System.ComponentModel.DataAnnotations;

public record CreateTodoInput(
  [Required(ErrorMessage = "A title is required to create a To-Do.")]
  [MinLength(1, ErrorMessage = "Title cannot be empty.")] string Title
);
