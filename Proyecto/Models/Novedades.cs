 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Novedades
    {
        [Key]
        public int NovedadesID { get; set; }
        [Display(Name = "Codigo novedad")]
        public int Codigo_Novedad { get; set; }
        [Display(Name = "Descripción")]
        [StringLength(250, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres", MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha de realización")]
        [Required(ErrorMessage = "Debe ingresar la {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd", ApplyFormatInEditMode = false)]
        public DateTime Fecha_Realizacion { get; set; }

        //public int personaID { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual ICollection<NE> NEs { get; set; }
    }
}