namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateView : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Product", "ViewCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Product", "ViewCount", c => c.Int(nullable: false));
        }
    }
}
