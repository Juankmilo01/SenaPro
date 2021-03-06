﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Tipo_Documento
    {
        [Key]
        [Display(Name = "Tipo documento ")]
        public int TipoDocumentoID { get; set; }
        [Display(Name = "Tipo documento ")]
        public string NombreDocumento { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}