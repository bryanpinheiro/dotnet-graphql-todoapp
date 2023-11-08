using dotnet_graphql_todoapp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<DatabaseContext>(
  options => options.UseSqlite("Data Source=database/todo.db")
);

builder.Services.AddTransient<ITodoRepository, TodoRepository>();

builder.Services
  .AddGraphQLServer()
  .RegisterService<ITodoRepository>()
  .AddQueryType<TodoQuery>()
  .AddMutationType<TodoMutation>();

var app = builder.Build();

app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

app.Run();
