using Gestion_Catalogue.Model;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Catalogue
{
    public class DbCatalogue : DbContext
    {
        public DbCatalogue(DbContextOptions<DbCatalogue> options)
            : base(options)
        {
        }

        public DbSet<Catalogue> Catalogues { get; set; }
    }
}
