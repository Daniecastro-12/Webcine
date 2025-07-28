namespace Webcine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAsientosRelacionFuncion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asientoes", "FuncionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Asientoes", "FuncionId");
            Sql("DELETE FROM [dbo].[Asientoes] WHERE FuncionId NOT IN (SELECT Id FROM [dbo].[Funcions])");
            AddForeignKey("dbo.Asientoes", "FuncionId", "dbo.Funcions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asientoes", "FuncionId", "dbo.Funcions");
            DropIndex("dbo.Asientoes", new[] { "FuncionId" });
            DropColumn("dbo.Asientoes", "FuncionId");
        }
    }
}
