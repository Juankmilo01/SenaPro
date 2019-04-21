using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Elementos
    {
        [Key]
        public int ElementosID { get; set; }
        [Display(Name = "Número serial")]
        [Required(ErrorMessage = "Debe ingresar el {0}")]
        //[Unique(ErrorMessage = "¡ Esto ya existe! ")]
        public string Numero_Serial { get; set; }
        [Display(Name = "Placa equipo")]
        [Required(ErrorMessage = "Debe ingresar la {0}")]
        public int Placa_Equipo { get; set; }
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }
        [Display(Name = "Detalle")]
        [StringLength(100, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres", MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string Detalle { get; set; }
        [Display(Name = "Marca")]
        public string Marca { get; set; }
        //[Display(Name = "Fecha Entrada")]
        //[Required(ErrorMessage = "Debe ingresar la {0}")]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd", ApplyFormatInEditMode = false)]
        //public DateTime Fecha_Entrada { get; set; }
        //[Display(Name = "Fecha Salida")]
        //[Required(ErrorMessage = "Debe ingresar la {0}")]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd", ApplyFormatInEditMode = false)]
        //public DateTime Fecha_Salida { get; set; }

        public int Tipo_ElementosID { get; set; }        
        public int Estado_ElementosID { get; set; }
        public int AmbientesID { get; set; }


        public virtual Tipo_Elementos Tipo_Elementos { get; set; }
        public virtual Estado_Elementos Estado_Elementos { get; set; }
        public virtual Ambientes Ambientes { get; set; }

        public virtual ICollection<EP> EPs { get; set; }
        public virtual ICollection<NE> NEs { get; set; }

    }
}