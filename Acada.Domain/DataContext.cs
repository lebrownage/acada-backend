using Acada.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acada.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Product = Set<Product>();
        }

        public virtual DbSet<Product> Product { get; set; }
    }
}