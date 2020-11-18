namespace CircularManagementSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Manytomanyrelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CircularDepartments",
                c => new
                    {
                        Circular_CircularId = c.Int(nullable: false),
                        Department_DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Circular_CircularId, t.Department_DepartmentId })
                .ForeignKey("dbo.Circulars", t => t.Circular_CircularId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId, cascadeDelete: true)
                .Index(t => t.Circular_CircularId)
                .Index(t => t.Department_DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CircularDepartments", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CircularDepartments", "Circular_CircularId", "dbo.Circulars");
            DropIndex("dbo.CircularDepartments", new[] { "Department_DepartmentId" });
            DropIndex("dbo.CircularDepartments", new[] { "Circular_CircularId" });
            DropTable("dbo.CircularDepartments");
        }
    }
}
