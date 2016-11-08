namespace SDCTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatevalidatemodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanVien", "HoTen", c => c.String(nullable: false));
            AlterColumn("dbo.NhanVien", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.NhanVien", "SDT", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanVien", "SDT", c => c.String());
            AlterColumn("dbo.NhanVien", "Email", c => c.String());
            AlterColumn("dbo.NhanVien", "HoTen", c => c.String());
        }
    }
}
