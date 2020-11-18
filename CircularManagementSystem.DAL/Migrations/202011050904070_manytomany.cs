namespace CircularManagementSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomany : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CircularDepartments", name: "Circular_CircularId", newName: "DepartmentId");
            RenameColumn(table: "dbo.CircularDepartments", name: "Department_DepartmentId", newName: "CircularId");
            RenameIndex(table: "dbo.CircularDepartments", name: "IX_Department_DepartmentId", newName: "IX_CircularId");
            RenameIndex(table: "dbo.CircularDepartments", name: "IX_Circular_CircularId", newName: "IX_DepartmentId");
            DropPrimaryKey("dbo.CircularDepartments");
            AddPrimaryKey("dbo.CircularDepartments", new[] { "CircularId", "DepartmentId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CircularDepartments");
            AddPrimaryKey("dbo.CircularDepartments", new[] { "Circular_CircularId", "Department_DepartmentId" });
            RenameIndex(table: "dbo.CircularDepartments", name: "IX_DepartmentId", newName: "IX_Circular_CircularId");
            RenameIndex(table: "dbo.CircularDepartments", name: "IX_CircularId", newName: "IX_Department_DepartmentId");
            RenameColumn(table: "dbo.CircularDepartments", name: "CircularId", newName: "Department_DepartmentId");
            RenameColumn(table: "dbo.CircularDepartments", name: "DepartmentId", newName: "Circular_CircularId");
        }
    }
}
