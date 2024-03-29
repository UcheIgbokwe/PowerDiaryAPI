using Domain.ChatEvents;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        // {
        //     return base.Set<TEntity>();
        // }

        public virtual DbSet<ChatEvent> ChatEvents { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}