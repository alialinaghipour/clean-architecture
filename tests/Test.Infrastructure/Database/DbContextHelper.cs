using Infrastructure.Tools;
using Microsoft.EntityFrameworkCore;

namespace Test.Infrastructure.Database;

public static class DbContextHelper
{
    public static void Save<TDbContext, TEntity>
        (this TDbContext dbContext, TEntity entity)
        where TDbContext : DbContext
        where TEntity : class, new()
    {
        dbContext.Add(entity);
        dbContext.SaveChanges();
    }

    public static void SaveRange<TDbContext, TEntity>
        (this TDbContext dbContext, params TEntity[] entities)
        where TDbContext : DbContext
        where TEntity : class, new()
    {
        entities.ForEach(entity => dbContext.Add(entity));
        dbContext.SaveChanges();
    }
}