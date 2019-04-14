﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class EP
    {
        [Key]
        public int EPID { get; set; }
        [Display(Name = "Estado de entrega")]
        public string Estado_Entrega { get; set; }
        [Display(Name = "Estado de salida")]
        public string Estado_Salida { get; set; }
        [Display(Name = "Disponibilidad")]
        public string Disponibilidad { get; set; }
        [Display(Name = "Cantidad prestada")]
        public int Cantidad_Prestada { get; set; }

        public int ElementosID { get; set; }
        public int PrestamosID { get; set; }

        public virtual Elementos Elementos { get; set; }
        public virtual Prestamos Prestamos { get; set; }
    }
}