using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Role
    {

        public Guid RoleId { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        public virtual ICollection<Utilisateur> Utilisateurs { get; set; } = new HashSet<Utilisateur>();
    }
}
