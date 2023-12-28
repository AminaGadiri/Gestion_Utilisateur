using Gestion_Catalogue.Model;

namespace Gestion_Catalogue.Repository
{
    public class CatalogueRepository : ICatalogueRepository
    {
        private readonly DbCatalogue dbContext;

        public CatalogueRepository(DbCatalogue dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<Catalogue> CreateAsync(Catalogue catalogue)
        {
            throw new NotImplementedException();
        }

        public Task<Catalogue?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Catalogue>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Catalogue?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Catalogue role)
        {
            throw new NotImplementedException();
        }
    }
}
