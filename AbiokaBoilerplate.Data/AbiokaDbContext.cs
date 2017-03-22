using Microsoft.EntityFrameworkCore;

namespace AbiokaBoilerplate.Data
{
    public class AbiokaDbContext : DbContext
    {
        public AbiokaDbContext(DbContextOptions<AbiokaDbContext> options)
            : base(options)
        {
        }
    }
}
