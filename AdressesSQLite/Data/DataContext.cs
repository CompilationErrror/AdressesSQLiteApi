using Microsoft.EntityFrameworkCore;

namespace AdressesSQLite.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
        }

        public DbSet<Adress> Adresses => Set<Adress>();
    }
}
