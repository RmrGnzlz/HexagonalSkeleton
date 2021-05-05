using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class MyContext : DbContextBase
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        #region DbSets
        public DbSet<User> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration on creation
            base.OnModelCreating(modelBuilder);
        }
    }
}