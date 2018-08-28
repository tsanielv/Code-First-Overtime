using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class BaseContext : DbContext
    { 
        public BaseContext() : base("Console.Overtime") { }

        public DbSet<Overtime.Department> Departments { get; set; }
        public DbSet<Overtime.Role> Roles { get; set; }
        public DbSet<Overtime.Employee> Employees { get; set; }
        public DbSet<Overtime.History_Employee> History_Employees { get; set; }
        public DbSet<Overtime.Customer> Customers { get; set; }
        public DbSet<Overtime.Tax> Taxes { get; set; }
        public DbSet<Overtime.OvertimeType> OvertimeTypes { get; set; }
        public DbSet<Overtime.Approve_History> Approve_Histories { get; set; }
        public DbSet<Overtime.DataOvertime> DataOvertimes { get; set; }
    }
}
