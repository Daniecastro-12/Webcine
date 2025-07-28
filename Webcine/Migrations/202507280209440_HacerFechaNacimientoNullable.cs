namespace Webcine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HacerFechaNacimientoNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personas", "FechaNacimiento", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personas", "FechaNacimiento", c => c.DateTime(nullable: false));
        }
    }
}
