using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Tipo_Elementos
    {
        [Key]
        public int Tipo_ElementosID { get; set; }
        [Display(Name = "Tipo elemento ")]
        public string Nombre_TipoElemento { get; set; }

        public virtual ICollection<Elementos> Elementos { get; set; }
        
    }
}