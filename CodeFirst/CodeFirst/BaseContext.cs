using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class BaseContext : DbContext
    { 
        public BaseContext() : base("Console.Overtime") {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<History_Employee> History_Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<OvertimeType> OvertimeTypes { get; set; }
        public DbSet<Approve_History> Approve_Histories { get; set; }
        public DbSet<DataOvertime> DataOvertimes { get; set; }
    }
}
