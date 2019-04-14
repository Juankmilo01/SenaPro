using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Ciudad
    {

        [Key]
        public int CuidadID { get; set; }
        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "Debe ingresar la {0}")]
        public string NombreCiudad { get; set; }
        [Display(Name = "Departamento ")]
        public int DepartamentoID { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }

    }
}