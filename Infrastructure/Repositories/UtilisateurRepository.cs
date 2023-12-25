using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly BiblioDBContext dbContext;

        public UtilisateurRepository(BiblioDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Utilisateur> CreateAsync(Utilisateur utilisateur)
        {
            await dbContext.Utilisateurs.AddAsync(utilisateur);
            await dbContext.SaveChangesAsync();
            return utilisateur;
        }

        public async Task<Utilisateur?> DeleteAsync(Guid id)
        {
            var existingUtilisateur = await dbContext.Utilisateurs.FirstOrDefaultAsync(x => x.UtilisateurId == id);

            if (existingUtilisateur == null)
            {
                return null;
            }

            dbContext.Utilisateurs.Remove(existingUtilisateur);
            await dbContext.SaveChangesAsync();
            return existingUtilisateur;
        }

        public async Task<List<Utilisateur>> GetAllAsync()
        {
            return await dbContext.Utilisateurs.ToListAsync();
        }

        public async Task<Utilisateur?> GetByIdAsync(Guid id)
        {
            return await dbContext.Utilisateurs.FirstOrDefaultAsync(x => x.UtilisateurId == id);
        }

        public async Task<bool> UpdateAsync(Utilisateur utilisateur)
        {

            if (utilisateur != null)
            {
                dbContext.Set<Utilisateur>().Update(utilisateur);
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
