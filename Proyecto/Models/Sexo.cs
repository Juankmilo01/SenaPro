using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Sexo
    {

        [Key]
        [Display(Name = "Sexo")]
        public int SexoID { get; set; }
        [Display(Name = "Sexo")]
        public string NombreSexo { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}