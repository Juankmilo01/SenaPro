using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Departamento
    {

        [Key]
        public int DepartamentoID { get; set; }
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Debe ingresar el {0}")]
        public string NombreDepartamento { get; set; }

        public virtual ICollection<Ciudad> Ciudads { get; set; }
    }
}