using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class RoleDto
    {
        //public Guid RoleId { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        //public virtual ICollection<UtilisateurDto> Utilisateurs { get; set; } = new HashSet<UtilisateurDto>();
    }
}
