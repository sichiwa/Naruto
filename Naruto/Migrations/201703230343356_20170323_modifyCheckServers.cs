namespace Naruto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170323_modifyCheckServers : DbMigration
    {
        public override void Up()
        {
            AddColumn("SDMGR.CheckServers", "EnableDataCheck", c => c.Boolean(nullable: false));
            AddColumn("SDMGR.CheckServers", "EnableLogCheck", c => c.Boolean(nullable: false));
            DropColumn("SDMGR.CheckServers", "DoChcek");
        }
        
        public override void Down()
        {
            AddColumn("SDMGR.CheckServers", "DoChcek", c => c.Boolean(nullable: false));
            DropColumn("SDMGR.CheckServers", "EnableLogCheck");
            DropColumn("SDMGR.CheckServers", "EnableDataCheck");
        }
    }
}
