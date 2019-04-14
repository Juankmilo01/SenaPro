using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Programa
    {

        [Key]
        [Display(Name = "Programa")]
        public int ProgramaID { get; set; }
        [Display(Name = "Programa")]
        [StringLength(100, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres", MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string NombrePrograma { get; set; }


        public virtual ICollection<Persona> Personas { get; set; }
    }
}