namespace Naruto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170323_changeName_from_CheckReporItems_to_CheckReportSummaries_addTable_CheckReporItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SDMGR.CheckReportSummaries",
                c => new
                    {
                        SN = c.Int(nullable: false, identity: true),
                        ServerName = c.String(maxLength: 100),
                        ServerIP = c.String(maxLength: 100),
                        DirCount = c.Int(nullable: false),
                        DataCount = c.Int(nullable: false),
                        LogCount = c.Int(nullable: false),
                        CheckResult = c.Boolean(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SN);
            
            AddColumn("SDMGR.CheckReportItems", "CheckDate", c => c.DateTime(nullable: false));
            AddColumn("SDMGR.CheckReportItems", "insertTime", c => c.DateTime(nullable: false));
            DropColumn("SDMGR.CheckReportItems", "DirCount");
            DropColumn("SDMGR.CheckReportItems", "DataCount");
            DropColumn("SDMGR.CheckReportItems", "LogCount");
            DropColumn("SDMGR.CheckReportItems", "CheckResult");
            DropColumn("SDMGR.CheckReportItems", "UpdateTime");
        }
        
        public override void Down()
        {
            AddColumn("SDMGR.CheckReportItems", "UpdateTime", c => c.DateTime(nullable: false));
            AddColumn("SDMGR.CheckReportItems", "CheckResult", c => c.Boolean(nullable: false));
            AddColumn("SDMGR.CheckReportItems", "LogCount", c => c.Int(nullable: false));
            AddColumn("SDMGR.CheckReportItems", "DataCount", c => c.Int(nullable: false));
            AddColumn("SDMGR.CheckReportItems", "DirCount", c => c.Int(nullable: false));
            DropColumn("SDMGR.CheckReportItems", "insertTime");
            DropColumn("SDMGR.CheckReportItems", "CheckDate");
            DropTable("SDMGR.CheckReportSummaries");
        }
    }
}
