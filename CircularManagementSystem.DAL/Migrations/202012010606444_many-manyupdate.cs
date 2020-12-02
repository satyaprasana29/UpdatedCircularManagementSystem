namespace CircularManagementSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manymanyupdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CircularDepartments", newName: "DepartmentCirculars");
            RenameColumn(table: "dbo.DepartmentCirculars", name: "CircularId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.DepartmentCirculars", name: "DepartmentId", newName: "CircularId");
            RenameColumn(table: "dbo.DepartmentCirculars", name: "__mig_tmp__0", newName: "DepartmentId");
            RenameIndex(table: "dbo.DepartmentCirculars", name: "IX_CircularId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.DepartmentCirculars", name: "IX_DepartmentId", newName: "IX_CircularId");
            RenameIndex(table: "dbo.DepartmentCirculars", name: "__mig_tmp__0", newName: "IX_DepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.DepartmentCirculars", name: "IX_DepartmentId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.DepartmentCirculars", name: "IX_CircularId", newName: "IX_DepartmentId");
            RenameIndex(table: "dbo.DepartmentCirculars", name: "__mig_tmp__0", newName: "IX_CircularId");
            RenameColumn(table: "dbo.DepartmentCirculars", name: "DepartmentId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.DepartmentCirculars", name: "CircularId", newName: "DepartmentId");
            RenameColumn(table: "dbo.DepartmentCirculars", name: "__mig_tmp__0", newName: "CircularId");
            RenameTable(name: "dbo.DepartmentCirculars", newName: "CircularDepartments");
        }
    }
}
