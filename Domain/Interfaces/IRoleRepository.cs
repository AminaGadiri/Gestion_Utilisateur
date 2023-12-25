using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(Guid id);

        Task<Role> CreateAsync(Role role);

        Task<bool> UpdateAsync(Role role);

        Task<Role?> DeleteAsync(Guid id);
        Task<int> SaveAsync();
    }
}
