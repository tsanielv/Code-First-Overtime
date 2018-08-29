namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Department : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DataOvertimes", new[] { "Customer_id" });
            DropIndex("dbo.DataOvertimes", new[] { "Employee_id" });
            DropIndex("dbo.DataOvertimes", new[] { "Tax_id" });
            DropIndex("dbo.Employees", new[] { "Department_id" });
            DropIndex("dbo.Employees", new[] { "Role_id" });
            DropIndex("dbo.History_Employee", new[] { "Employee_id" });
            AlterColumn("dbo.DataOvertimes", "Employee_id", c => c.Int());
            AlterColumn("dbo.DataOvertimes", "Tax_id", c => c.Int());
            AlterColumn("dbo.DataOvertimes", "Customer_id", c => c.Int());
            AlterColumn("dbo.Employees", "Department_id", c => c.Int());
            AlterColumn("dbo.Employees", "Role_id", c => c.Int());
            AlterColumn("dbo.History_Employee", "Employee_id", c => c.Int());
            CreateIndex("dbo.DataOvertimes", "Customer_id");
            CreateIndex("dbo.DataOvertimes", "Employee_id");
            CreateIndex("dbo.DataOvertimes", "Tax_id");
            CreateIndex("dbo.Employees", "Department_id");
            CreateIndex("dbo.Employees", "Role_id");
            CreateIndex("dbo.History_Employee", "Employee_id");
            DropColumn("dbo.Approve_History", "Overtime_id");
            DropColumn("dbo.DataOvertimes", "type_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DataOvertimes", "type_id", c => c.Int(nullable: false));
            AddColumn("dbo.Approve_History", "Overtime_id", c => c.Int(nullable: false));
            DropIndex("dbo.History_Employee", new[] { "Employee_id" });
            DropIndex("dbo.Employees", new[] { "Role_id" });
            DropIndex("dbo.Employees", new[] { "Department_id" });
            DropIndex("dbo.DataOvertimes", new[] { "Tax_id" });
            DropIndex("dbo.DataOvertimes", new[] { "Employee_id" });
            DropIndex("dbo.DataOvertimes", new[] { "Customer_id" });
            AlterColumn("dbo.History_Employee", "Employee_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Role_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Department_id", c => c.Int(nullable: false));
            AlterColumn("dbo.DataOvertimes", "Customer_id", c => c.Int(nullable: false));
            AlterColumn("dbo.DataOvertimes", "Tax_id", c => c.Int(nullable: false));
            AlterColumn("dbo.DataOvertimes", "Employee_id", c => c.Int(nullable: false));
            CreateIndex("dbo.History_Employee", "Employee_id");
            CreateIndex("dbo.Employees", "Role_id");
            CreateIndex("dbo.Employees", "Department_id");
            CreateIndex("dbo.DataOvertimes", "Tax_id");
            CreateIndex("dbo.DataOvertimes", "Employee_id");
            CreateIndex("dbo.DataOvertimes", "Customer_id");
        }
    }
}
