using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Ambientes
    {
        [Key]
        public int AmbientesID { get; set; }
        [Display(Name = "Número ambiente")]
        [Required(ErrorMessage = "Debe ingresar el {0}")]
        public string Numero_Ambiente { get; set; }
        [Display(Name = "Ubicación")]
        [Required(ErrorMessage = "Debe ingresar la {0}")]
        public string Ubicacion { get; set; }
        [Display(Name = "Piso")]
        [Required(ErrorMessage = "Debe ingresar el {0}")]
        public string Detalle_Piso { get; set; }

        public int Estado_AmbientesID { get; set; }
        public int personaID { get; set; }

        public virtual ICollection<Elementos> Elementos { get; set; }
        public virtual Estado_Ambientes Estado_Ambientes { get; set; }
        public virtual Persona Persona { get; set; }
    }
}