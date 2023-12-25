using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DB
{
    public class BiblioDBContext : DbContext
    {
        public BiblioDBContext(DbContextOptions<BiblioDBContext> options)
            : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUtilisateur> RoleUtilisateurs { get; set; }

    }
}
