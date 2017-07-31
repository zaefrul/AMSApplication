namespace BMSApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faiz4table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false),
                        CreatedBy = c.String(),
                        Created = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Couriers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Barcode = c.String(),
                        Quantity = c.Int(nullable: false),
                        Remarks = c.String(),
                        CostPrice = c.Double(nullable: false),
                        Status = c.String(),
                        Category = c.String(),
                        CreatedBy = c.String(),
                        Created = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ColorId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.ColorId)
                .Index(t => t.SizeId);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false),
                        CreatedBy = c.String(),
                        Created = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sell_Price",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        CreatedBy = c.String(),
                        Created = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Modified = c.DateTime(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Contact1 = c.String(),
                        Contact2 = c.String(),
                        Email = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Sell_Price", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.Items", "ColorId", "dbo.Colors");
            DropIndex("dbo.Sell_Price", new[] { "ItemId" });
            DropIndex("dbo.Items", new[] { "SizeId" });
            DropIndex("dbo.Items", new[] { "ColorId" });
            DropTable("dbo.Sell_Price");
            DropTable("dbo.Sizes");
            DropTable("dbo.Items");
            DropTable("dbo.Couriers");
            DropTable("dbo.Colors");
        }
    }
}
