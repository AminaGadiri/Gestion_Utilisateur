using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Utilisateur
    {
        public Guid UtilisateurId { get; set; }
        [Required]
        [MaxLength(15)]
        public string Nom { get; set; }
        [Required]
        [MaxLength(15)]
        public string Prenom { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Ecole { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public bool JobInTech { get; set; } = false;

        public virtual ICollection<Role> Roles { get; set; } = new HashSet<Role>();



    }
}
