namespace dotnet_graphql_todoapp;


using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
  public DatabaseContext(DbContextOptions<DatabaseContext> options)
      : base(options) { }

  public DbSet<Todo> Todos => Set<Todo>();

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if(!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlite("Data Source=database/todo.db");
    }
  }
}
