namespace Naruto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyCheckServers_IP_to200 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("SDMGR.CheckServers", "IP", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("SDMGR.CheckServers", "IP", c => c.String(maxLength: 100));
        }
    }
}
