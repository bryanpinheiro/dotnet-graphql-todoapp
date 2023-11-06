using dotnet_graphql_todoapp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDb>(options =>
{
  options.UseSqlite("Data Source=database/todo.db");
});

builder.Services
  .AddGraphQLServer()
  .AddQueryType<TodoQuery>();

var app = builder.Build();

app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

app.Run();
