using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB
{
    public class BiblioAuthDBContext : IdentityDbContext
    {
        public BiblioAuthDBContext(DbContextOptions<BiblioAuthDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "a71a55d6-99d7-4123-b4e0-1218ecb90e3e";
            var etudiantRoleId = "c309fa92-2123-47be-b397-a1c77adb502c";
            var etudiantVIPRoleId = "8d38749d-b8a4-455e-9c2d-dd0113e80797";
            var etudiantBronzeRoleId = "952ccc55-ef06-46a6-a5cf-50de8f3cbb6d";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = etudiantRoleId,
                    ConcurrencyStamp = etudiantRoleId,
                    Name = "Etudiant",
                    NormalizedName = "Etudiant".ToUpper()
                },
                new IdentityRole
                {
                    Id = etudiantVIPRoleId,
                    ConcurrencyStamp = etudiantVIPRoleId,
                    Name = "Etudiant VIP",
                    NormalizedName = "Etudiant VIP".ToUpper()
                },
                new IdentityRole
                {
                    Id =  etudiantBronzeRoleId,
                    ConcurrencyStamp =  etudiantBronzeRoleId,
                    Name = "Etudiant Bronze",
                    NormalizedName = "Etudiant Bronze".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

