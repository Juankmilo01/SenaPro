using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senalai.Models
{
    public class Persona
    {
        [Key] 
        public int personaID { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(30, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }
        [Display(Name = "Primer apellido")]
        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(30, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Apellido_Primario { get; set; }
        [Display(Name = "Segundo apellido")]
        [StringLength(30, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Apellido_Segundo { get; set; }
        [Display(Name = "Tipo Documento")]
        public int TipoDocumentoID { get; set; }
        [Display(Name = "Número Documento")]
        public int NumeroDocumento { get; set; }
        [Display(Name = "Sexo")]
        public int SexoID { get; set; }
        [Display(Name = "Ciudad ")]
        public int CuidadID { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debe ingresar la {0}")]
        [StringLength(50, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres", MinimumLength = 5)]
        public string Direccion { get; set; }
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(15, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Phone]
        public string Telefono { get; set; }
        [Display(Name = "Número celular")]
        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(15, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Phone]
        public string Numero_Celular { get; set; }
        [Display(Name = "Correo electronico")]
        [EmailAddress]
        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(30, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres", MinimumLength = 5)]
        public string Email { get; set; }
        [Display(Name = "Programa ")]
        public int ProgramaID { get; set; }
        [Display(Name = "Número ficha")]
        public string Numero_Ficha { get; set; }
        [Display(Name = "Estado ")]
        public int EstadoID { get; set; }
        [Display(Name = "Roles ")]
        public int RolesID { get; set; }


        public virtual Ciudad Ciudad { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Programa Programa { get; set; }
        public virtual Roles Roles { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual Tipo_Documento Tipo_Documento { get; set; }
        public int NovedadesID { get; set; }

        public virtual ICollection<Novedades> Novedades { get; set; }
        public virtual ICollection<PP> PPs { get; set; }
        public virtual ICollection<Ambientes> Ambientes { get; set; }


    }
}