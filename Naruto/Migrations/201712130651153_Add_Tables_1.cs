namespace Naruto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Tables_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SDMGR.CheckedDataFiles",
                c => new
                    {
                        SN = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 1000),
                        FilePath = c.String(maxLength: 1000),
                        CheckDate = c.DateTime(nullable: false),
                        CheckSN = c.Int(nullable: false),
                        ServerSN = c.Int(nullable: false),
                        isFile = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        LastAccessTime = c.DateTime(nullable: false),
                        LastWriteTime = c.DateTime(nullable: false),
                        ReadOnly = c.Boolean(nullable: false),
                        HashValue = c.String(maxLength: 600),
                        Checked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SN);
            
            CreateTable(
                "SDMGR.CheckedDirs",
                c => new
                    {
                        SN = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 1000),
                        CheckDate = c.DateTime(nullable: false),
                        CheckSN = c.Int(nullable: false),
                        ServerSN = c.Int(nullable: false),
                        HashValue = c.String(maxLength: 600),
                        Checked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SN);
            
            CreateTable(
                "dbo.CheckedMainLogs",
                c => new
                    {
                        SN = c.Int(nullable: false, identity: true),
                        CheckDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SN);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CheckedMainLogs");
            DropTable("SDMGR.CheckedDirs");
            DropTable("SDMGR.CheckedDataFiles");
        }
    }
}
