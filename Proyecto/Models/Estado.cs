using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Estado
    {

        [Key]
        [Display(Name = "Estado")]
        public int EstadoID { get; set; }
        [Display(Name = "Estado")]
        public string NombreEstado { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}