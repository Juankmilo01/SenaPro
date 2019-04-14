using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Roles
    {
        [Key]
        [Display(Name = "Rol")]
        public int RolesID { get; set; }
        [Display(Name = "Rol")]
        public string NombreRoles { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}