using Microsoft.EntityFrameworkCore;

namespace Crud.Data
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext(DbContextOptions<CrudDbContext> opts) : base(opts)
        {
        }

        public DbSet<Models.Crud> Cruds { get; set; }
    }
}