using Gestion_Catalogue1.Model;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Catalogue1.Repository
{
    public class CatalogueRepository : ICatalogueRepository
    {
        private readonly CatalogueDbContext dbContext;

        public CatalogueRepository(CatalogueDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Catalogue> CreateAsync(Catalogue catalogue)
        {
            await dbContext.Catalogues.AddAsync(catalogue);
            await dbContext.SaveChangesAsync();
            return catalogue;
        }

        public async Task<Catalogue?> DeleteAsync(Guid id)
        {
            var existingCatalogue = await dbContext.Catalogues.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCatalogue == null)
            {
                return null;
            }

            dbContext.Catalogues.Remove(existingCatalogue);
            await dbContext.SaveChangesAsync();
            return existingCatalogue;
        }

        public async Task<List<Catalogue>> GetAllAsync()
        {
            return await dbContext.Catalogues.ToListAsync();
        }

        public async Task<Catalogue?> GetByIdAsync(Guid id)
        {
            return await dbContext.Catalogues.FirstOrDefaultAsync(x => x.Id == id);
        }

       

        public async Task<bool> UpdateAsync(Catalogue catalogue)
        {
            if (catalogue != null)
            {
                dbContext.Set<Catalogue>().Update(catalogue);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
