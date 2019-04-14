namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.tipo_documento");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tipo_documento",
                c => new
                    {
                        TipoDocumentoID = c.Int(nullable: false, identity: true),
                        NombreDocumento = c.String(),
                    })
                .PrimaryKey(t => t.TipoDocumentoID);
            
        }
    }
}
