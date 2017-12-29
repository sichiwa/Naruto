namespace Naruto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_checkcosttype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("SDMGR.CheckServers", "CheckCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("SDMGR.CheckServers", "CheckCost", c => c.Int(nullable: false));
        }
    }
}
