using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTest
{
    public class UtilisateurDto
    {
        
        public string Nom { get; set; }
       
        public string Prenom { get; set; }
      
        public string Email { get; set; }
      
        public string Password { get; set; }
       
        public string Ecole { get; set; }
        
        public string Adresse { get; set; }
        
        public bool JobInTech { get; set; } = false;
    }
}
