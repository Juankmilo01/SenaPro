using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    public class tipo_documento
    {
        [Key]
        [Display(Name = "Tipo documento ")]
        public int TipoDocumentoID { get; set; }
        [Display(Name = "Tipo documento ")]
        public string NombreDocumento { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }


    }
}