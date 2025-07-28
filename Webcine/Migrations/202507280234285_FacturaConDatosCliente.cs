namespace Webcine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FacturaConDatosCliente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "ClienteId", "dbo.Personas");
            DropIndex("dbo.Facturas", new[] { "ClienteId" });
            RenameColumn(table: "dbo.Facturas", name: "ClienteId", newName: "Cliente_Id");
            AddColumn("dbo.Facturas", "NombreCliente", c => c.String());
            AddColumn("dbo.Facturas", "ApellidoCliente", c => c.String());
            AddColumn("dbo.Facturas", "EmailCliente", c => c.String());
            AlterColumn("dbo.Facturas", "Cliente_Id", c => c.Int());
            CreateIndex("dbo.Facturas", "Cliente_Id");
            AddForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Personas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Personas");
            DropIndex("dbo.Facturas", new[] { "Cliente_Id" });
            AlterColumn("dbo.Facturas", "Cliente_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Facturas", "EmailCliente");
            DropColumn("dbo.Facturas", "ApellidoCliente");
            DropColumn("dbo.Facturas", "NombreCliente");
            RenameColumn(table: "dbo.Facturas", name: "Cliente_Id", newName: "ClienteId");
            CreateIndex("dbo.Facturas", "ClienteId");
            AddForeignKey("dbo.Facturas", "ClienteId", "dbo.Personas", "Id", cascadeDelete: true);
        }
    }
}
