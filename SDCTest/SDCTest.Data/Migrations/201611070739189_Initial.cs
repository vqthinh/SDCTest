namespace SDCTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        Email = c.String(),
                        SDT = c.String(),
                        TinhThanhID = c.Int(nullable: false),
                        QuanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Quan", t => t.QuanID, cascadeDelete: false)
                .ForeignKey("dbo.TinhThanh", t => t.TinhThanhID, cascadeDelete: false)
                .Index(t => t.TinhThanhID)
                .Index(t => t.QuanID);
            
            CreateTable(
                "dbo.Quan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenQuan = c.String(),
                        TinhThanhID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TinhThanh", t => t.TinhThanhID, cascadeDelete: false)
                .Index(t => t.TinhThanhID);
            
            CreateTable(
                "dbo.TinhThanh",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenTinhThanh = c.String(),
                        MaVung = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhanVien", "TinhThanhID", "dbo.TinhThanh");
            DropForeignKey("dbo.NhanVien", "QuanID", "dbo.Quan");
            DropForeignKey("dbo.Quan", "TinhThanhID", "dbo.TinhThanh");
            DropIndex("dbo.Quan", new[] { "TinhThanhID" });
            DropIndex("dbo.NhanVien", new[] { "QuanID" });
            DropIndex("dbo.NhanVien", new[] { "TinhThanhID" });
            DropTable("dbo.TinhThanh");
            DropTable("dbo.Quan");
            DropTable("dbo.NhanVien");
        }
    }
}
