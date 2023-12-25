using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RoleUtilisateur
    {
        [Key]
        public Guid RoleUtisateurId { get; set; }
        [Required]

        public Guid RoleId { get; set; }
        [Required]

        public Guid UtilisateurId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }



    }
}
