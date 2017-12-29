namespace Naruto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170323_modifyCheckServer : DbMigration
    {
        public override void Up()
        {
            AddColumn("SDMGR.CheckServers", "CheckStartTime", c => c.DateTime(nullable: false));
            AddColumn("SDMGR.CheckServers", "CheckEndTime", c => c.DateTime(nullable: false));
            AddColumn("SDMGR.CheckServers", "CheckCost", c => c.Int(nullable: false));
            AddColumn("SDMGR.CheckServers", "Finish", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("SDMGR.CheckServers", "Finish");
            DropColumn("SDMGR.CheckServers", "CheckCost");
            DropColumn("SDMGR.CheckServers", "CheckEndTime");
            DropColumn("SDMGR.CheckServers", "CheckStartTime");
        }
    }
}
