namespace CircularManagementSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        EmployeeEmail = c.String(nullable: false, maxLength: 255),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.EmployeeEmail, unique: true);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 30),
                        EmployeePhoneNumber = c.Long(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        EmployeeGender = c.String(nullable: false),
                        EmployeeEmail = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeDesignations", t => t.DesignationId, cascadeDelete: true)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.EmployeePhoneNumber, unique: true)
                .Index(t => t.ManagerId)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.EmployeeDesignations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
                        ManagerName = c.String(),
                    })
                .PrimaryKey(t => t.ManagerId);
            
            CreateTable(
                "dbo.Circulars",
                c => new
                    {
                        CircularId = c.Int(nullable: false, identity: true),
                        CircularName = c.String(nullable: false),
                        FilePath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CircularId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.EmployeeDesignations");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.Employees", new[] { "ManagerId" });
            DropIndex("dbo.Employees", new[] { "EmployeePhoneNumber" });
            DropIndex("dbo.Accounts", new[] { "EmployeeEmail" });
            DropIndex("dbo.Accounts", new[] { "EmployeeId" });
            DropTable("dbo.Circulars");
            DropTable("dbo.Managers");
            DropTable("dbo.EmployeeDesignations");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Accounts");
        }
    }
}
