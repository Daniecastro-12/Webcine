namespace Webcine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregaFacturaYDetalleFactura : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "MetodoPago_Id", "dbo.MetodoPagoes");
            DropForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Personas");
            DropIndex("dbo.Facturas", new[] { "Cliente_Id" });
            DropIndex("dbo.Facturas", new[] { "MetodoPago_Id" });
            RenameColumn(table: "dbo.Facturas", name: "Cliente_Id", newName: "ClienteId");
            RenameColumn(table: "dbo.DetalleFacturas", name: "_facturaId", newName: "FacturaId");
            RenameIndex(table: "dbo.DetalleFacturas", name: "IX__facturaId", newName: "IX_FacturaId");
            AddColumn("dbo.DetalleFacturas", "Tipo", c => c.String());
            AlterColumn("dbo.Facturas", "ClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Facturas", "ClienteId");
            AddForeignKey("dbo.Facturas", "ClienteId", "dbo.Personas", "Id", cascadeDelete: true);
            DropColumn("dbo.Facturas", "_clienteId");
            DropColumn("dbo.Facturas", "_metodoPagoId");
            DropColumn("dbo.Facturas", "MetodoPago_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facturas", "MetodoPago_Id", c => c.Int());
            AddColumn("dbo.Facturas", "_metodoPagoId", c => c.Int(nullable: false));
            AddColumn("dbo.Facturas", "_clienteId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Facturas", "ClienteId", "dbo.Personas");
            DropIndex("dbo.Facturas", new[] { "ClienteId" });
            AlterColumn("dbo.Facturas", "ClienteId", c => c.Int());
            DropColumn("dbo.DetalleFacturas", "Tipo");
            RenameIndex(table: "dbo.DetalleFacturas", name: "IX_FacturaId", newName: "IX__facturaId");
            RenameColumn(table: "dbo.DetalleFacturas", name: "FacturaId", newName: "_facturaId");
            RenameColumn(table: "dbo.Facturas", name: "ClienteId", newName: "Cliente_Id");
            CreateIndex("dbo.Facturas", "MetodoPago_Id");
            CreateIndex("dbo.Facturas", "Cliente_Id");
            AddForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Personas", "Id");
            AddForeignKey("dbo.Facturas", "MetodoPago_Id", "dbo.MetodoPagoes", "Id");
        }
    }
}
