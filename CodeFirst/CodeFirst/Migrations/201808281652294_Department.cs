namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Department : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Approve_History",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        status = c.String(),
                        Overtime_id = c.Int(nullable: false),
                        DataOvertime_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DataOvertimes", t => t.DataOvertime_id)
                .Index(t => t.DataOvertime_id);
            
            CreateTable(
                "dbo.DataOvertimes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        overtime_pay = c.Int(nullable: false),
                        status = c.String(),
                        employee_id = c.Int(nullable: false),
                        tax_id = c.Int(nullable: false),
                        type_id = c.Int(nullable: false),
                        customer_id = c.Int(nullable: false),
                        Customer_id = c.Int(),
                        Employee_id = c.Int(),
                        OvertimeType_id = c.Int(),
                        Tax_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customer_id)
                .ForeignKey("dbo.Employees", t => t.Employee_id)
                .ForeignKey("dbo.OvertimeTypes", t => t.OvertimeType_id)
                .ForeignKey("dbo.Taxes", t => t.Tax_id)
                .Index(t => t.Customer_id)
                .Index(t => t.Employee_id)
                .Index(t => t.OvertimeType_id)
                .Index(t => t.Tax_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        email = c.String(),
                        password = c.String(),
                        salary = c.Int(nullable: false),
                        department_id = c.Int(nullable: false),
                        role_id = c.Int(nullable: false),
                        Department_id = c.Int(),
                        Role_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departments", t => t.Department_id)
                .ForeignKey("dbo.Roles", t => t.Role_id)
                .Index(t => t.Department_id)
                .Index(t => t.Role_id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.History_Employee",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        date_deleted = c.DateTime(nullable: false),
                        employee_id = c.Int(nullable: false),
                        Employee_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Employees", t => t.Employee_id)
                .Index(t => t.Employee_id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OvertimeTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        detail = c.String(),
                        amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DataOvertimes", "Tax_id", "dbo.Taxes");
            DropForeignKey("dbo.DataOvertimes", "OvertimeType_id", "dbo.OvertimeTypes");
            DropForeignKey("dbo.Employees", "Role_id", "dbo.Roles");
            DropForeignKey("dbo.History_Employee", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Department_id", "dbo.Departments");
            DropForeignKey("dbo.DataOvertimes", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.DataOvertimes", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Approve_History", "DataOvertime_id", "dbo.DataOvertimes");
            DropIndex("dbo.History_Employee", new[] { "Employee_id" });
            DropIndex("dbo.Employees", new[] { "Role_id" });
            DropIndex("dbo.Employees", new[] { "Department_id" });
            DropIndex("dbo.DataOvertimes", new[] { "Tax_id" });
            DropIndex("dbo.DataOvertimes", new[] { "OvertimeType_id" });
            DropIndex("dbo.DataOvertimes", new[] { "Employee_id" });
            DropIndex("dbo.DataOvertimes", new[] { "Customer_id" });
            DropIndex("dbo.Approve_History", new[] { "DataOvertime_id" });
            DropTable("dbo.Taxes");
            DropTable("dbo.OvertimeTypes");
            DropTable("dbo.Roles");
            DropTable("dbo.History_Employee");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.DataOvertimes");
            DropTable("dbo.Approve_History");
        }
    }
}
