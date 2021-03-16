namespace DbEmployees.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCompleto = c.String(),
                        SueldoBase = c.Double(nullable: false),
                        IdtipoEmpleado = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoEmpleados", t => t.IdtipoEmpleado)
                .Index(t => t.IdtipoEmpleado);
            
            CreateTable(
                "dbo.TipoEmpleados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        NombreUsuario = c.String(),
                        Contrasena = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleados", "IdtipoEmpleado", "dbo.TipoEmpleados");
            DropIndex("dbo.Empleados", new[] { "IdtipoEmpleado" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.TipoEmpleados");
            DropTable("dbo.Empleados");
        }
    }
}
