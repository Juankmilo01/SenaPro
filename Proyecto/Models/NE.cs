using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class NE
    {
        [Key]
        public int NEID { get; set; }
        public string Estado_Entrega { get; set; }
        public string Estado_Devolucion { get; set; }

        public int ElementosID { get; set; }
        public int NovedadesID { get; set; }

        public virtual Elementos Elementos { get; set; }
        public virtual Novedades Novedades { get; set; }
    }
}