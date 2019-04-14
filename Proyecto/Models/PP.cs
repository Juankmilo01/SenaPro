using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class PP
    {
        [Key]
        public int PPID { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public int personaID { get; set; }
        public int PrestamosID { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual Prestamos Prestamos { get; set; }

    }
}