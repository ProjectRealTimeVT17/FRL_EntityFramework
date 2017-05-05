namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Species = c.String(),
                        ManEater = c.Boolean(nullable: false),
                        Zoo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zoos", t => t.Zoo_Id)
                .Index(t => t.Zoo_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Zoo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zoos", t => t.Zoo_Id)
                .Index(t => t.Zoo_Id);
            
            CreateTable(
                "dbo.Zoos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Manager_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Manager_Id)
                .Index(t => t.Manager_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zoos", "Manager_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Zoo_Id", "dbo.Zoos");
            DropForeignKey("dbo.Animals", "Zoo_Id", "dbo.Zoos");
            DropIndex("dbo.Zoos", new[] { "Manager_Id" });
            DropIndex("dbo.Employees", new[] { "Zoo_Id" });
            DropIndex("dbo.Animals", new[] { "Zoo_Id" });
            DropTable("dbo.Zoos");
            DropTable("dbo.Employees");
            DropTable("dbo.Animals");
        }
    }
}
