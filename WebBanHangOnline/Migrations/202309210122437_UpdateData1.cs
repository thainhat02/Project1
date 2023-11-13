namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateData1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Post", "SeoTitle", c => c.String());
            AddColumn("dbo.tb_Post", "SeoDescription", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_Post", "SeoKeywords", c => c.String());
            AddColumn("dbo.tb_Product", "SeoTitle", c => c.String());
            AddColumn("dbo.tb_Product", "SeoDescription", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_Product", "SeoKeywords", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "SeoKeywords");
            DropColumn("dbo.tb_Product", "SeoDescription");
            DropColumn("dbo.tb_Product", "SeoTitle");
            DropColumn("dbo.tb_Post", "SeoKeywords");
            DropColumn("dbo.tb_Post", "SeoDescription");
            DropColumn("dbo.tb_Post", "SeoTitle");
        }
    }
}
