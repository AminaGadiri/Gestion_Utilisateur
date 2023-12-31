using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UtilisateurDto
    {
        // public Guid UtilisateurId { get; set; }
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
        
    }
}
