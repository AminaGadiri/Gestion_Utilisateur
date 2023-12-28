using Gestion_Catalogue1.Model;

namespace Gestion_Catalogue1.Repository
{
    public interface ICatalogueRepository
    {
        Task<List<Catalogue>> GetAllAsync();
        Task<Catalogue?> GetByIdAsync(Guid id);

        Task<Catalogue> CreateAsync(Catalogue catalogue);

        Task<bool> UpdateAsync(Catalogue catalogue);

        Task<Catalogue?> DeleteAsync(Guid id);
        Task<int> SaveAsync();
    }
}
