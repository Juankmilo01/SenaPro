using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Estado_Elementos
    {
        [Key]
        public int Estado_ElementosID { get; set; }
        public string Nombre_Estado { get; set; }

        public virtual ICollection<Elementos> Elementos { get; set; }

    }
}