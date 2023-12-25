using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUtilisateurRepository
    {
        Task<List<Utilisateur>> GetAllAsync();
        Task<Utilisateur?> GetByIdAsync(Guid id);

        Task<Utilisateur> CreateAsync(Utilisateur utilisateur);

        Task<bool> UpdateAsync(Utilisateur utilisateur);

        Task<Utilisateur?> DeleteAsync(Guid id);
        Task<int> SaveAsync();
    }
}
