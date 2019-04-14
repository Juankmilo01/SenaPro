using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Estado_Ambientes
    {
        [Key]
        public int Estado_AmbientesID { get; set; }
        public string Nombre_Estado { get; set; }

      
        public virtual ICollection<Ambientes> Ambientes { get; set; }
    }
}