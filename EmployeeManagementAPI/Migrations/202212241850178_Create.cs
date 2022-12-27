namespace EmployeeManagementAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin_details",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(),
                        AdminEmail = c.String(),
                        AdminPassword = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Emp_Detail",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        EmpName = c.String(),
                        EmpEmail = c.String(),
                        EmpPassword = c.String(),
                        EmpDetails = c.String(),
                        EmpSalary = c.String(),
                        EmpDesignation = c.String(),
                        EpLocation = c.String(),
                    })
                .PrimaryKey(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Emp_Detail");
            DropTable("dbo.Admin_details");
        }
    }
}
