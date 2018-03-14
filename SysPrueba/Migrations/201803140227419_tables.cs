namespace SysPrueba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        idEstudiante = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 255),
                        Apellidos = c.String(nullable: false, maxLength: 255),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idEstudiante);
            
            CreateTable(
                "dbo.Telefonoes",
                c => new
                    {
                        idTelefono = c.Int(nullable: false, identity: true),
                        Estudiante_id = c.Int(nullable: false),
                        Telf = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.idTelefono)
                .ForeignKey("dbo.Estudiantes", t => t.Estudiante_id, cascadeDelete: true)
                .Index(t => t.Estudiante_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefonoes", "Estudiante_id", "dbo.Estudiantes");
            DropIndex("dbo.Telefonoes", new[] { "Estudiante_id" });
            DropTable("dbo.Telefonoes");
            DropTable("dbo.Estudiantes");
        }
    }
}
