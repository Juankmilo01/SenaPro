using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    public class ProyectoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProyectoContext() : base("name=ProyectoContext")
        {
        }

        public System.Data.Entity.DbSet<Senalai.Models.Tipo_Elementos> Tipo_Elementos { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Elementos> Elementos { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Ambientes> Ambientes { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Estado_Elementos> Estado_Elementos { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Prestamos> Prestamos { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Estado_Ambientes> Estado_Ambientes { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Persona> Personas { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Ciudad> Ciudads { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Estado> Estadoes { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Programa> Programas { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Roles> Roles { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Sexo> Sexoes { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Tipo_Documento> Tipo_Documento { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Departamento> Departamentoes { get; set; }

        public System.Data.Entity.DbSet<Senalai.Models.Novedades> Novedades { get; set; }
    }
}
