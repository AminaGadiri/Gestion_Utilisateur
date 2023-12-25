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
    public class RoleRepository : IRoleRepository
    {
        private readonly BiblioDBContext dbContext;

        public RoleRepository(BiblioDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Role> CreateAsync(Role role)
        {
            await dbContext.Roles.AddAsync(role);
            await dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role?> DeleteAsync(Guid id)
        {
            var existingRole = await dbContext.Roles.FirstOrDefaultAsync(x => x.RoleId == id);

            if (existingRole == null)
            {
                return null;
            }

            dbContext.Roles.Remove(existingRole);
            await dbContext.SaveChangesAsync();
            return existingRole;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await dbContext.Roles.ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(Guid id)
        {
            return await dbContext.Roles.FirstOrDefaultAsync(x => x.RoleId == id);
        }

        public async Task<bool> UpdateAsync(Role role)
        {

            if (role != null)
            {
                dbContext.Set<Role>().Update(role);
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
