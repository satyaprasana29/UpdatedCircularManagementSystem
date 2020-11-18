namespace CircularManagementSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22102020 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Managers", "ManagerName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Managers", "ManagerName", c => c.String());
        }
    }
}
