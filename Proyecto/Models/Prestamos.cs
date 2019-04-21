using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamosID { get; set; }
        //[Display(Name = "Cantidad")]
        //[Required(ErrorMessage = "Debe ingresar la {0}")]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd", ApplyFormatInEditMode = false)]
        //public int Cantidad { get; set; }
        public string Estado_Disposicion { get; set; }
        //public DateTime Fecha_Prestamo { get; set; }
        //public DateTime Fecha_Devolucion { get; set; }
        public DateTime Fecha_Inicial { get; set; }
        public DateTime Fecha_Final { get; set; }
        public string Descripcion { get; set; }
        //public string Tipo_Prestamo { get; set; }
        //public int ElementosID { get; set; }

        public virtual ICollection<PP> PPs { get; set; }
        public virtual ICollection<EP> EPs { get; set; }

    }
}