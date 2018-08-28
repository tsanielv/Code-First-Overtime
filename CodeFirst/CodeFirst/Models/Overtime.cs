using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    class Overtime
    { 
        public class Department
        {
            [Key]
            public int id { get; set; }
            public string name { get; set; }
            public virtual List<Employee> Employees { get; set; }

        }

        public class Role
        {
            [Key]
            public int id { get; set; }
            public string name { get; set; }
            public virtual List<Employee> Employees { get; set; }
        }

        public class Employee
        {
            [Key]
            public int id { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public char gender { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public int salary { get; set; }
            public int department_id { get; set; }
            public int role_id { get; set; }
            public virtual Department Department { get; set; }
            public virtual Role Role { get; set; }
            public virtual List<History_Employee> History_Employees { get; set; }
            public virtual List<DataOvertime> DataOvertimes { get; set; }
        }

        public class History_Employee
        {
            [Key]
            public int id { get; set; }
            public string status { get; set; }
            public DateTime date_deleted { get; set; }
            public int employee_id { get; set; }
            public virtual Employee Employee { get; set; }
        }

        public class Customer
        {
            [Key]
            public int id { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public virtual List<DataOvertime> DataOvertimes { get; set; }

        }
    
        public class Tax
        {
            [Key]
            public int id { get; set; }
            public char type { get; set; }
            public int amount { get; set; }
            public virtual List<DataOvertime> DataOvertimes { get; set; }

        }

        public class OvertimeType
        {
            [Key]
            public int id { get; set; }
            public char type { get; set; }
            public string detail { get; set; }
            public int amount { get; set; }
            public virtual List<DataOvertime> DataOvertimes { get; set; }
        }

        public class DataOvertime
        {
            [Key]
            public int id { get; set; }
            public DateTime date { get; set; }
            public int overtime_pay { get; set; }
            public string status { get; set; }

            public int employee_id { get; set; }
            public int tax_id { get; set; }
            public int type_id { get; set; }
            public int customer_id { get; set; }

            public virtual Employee Employee { get; set; }
            public virtual Tax Tax { get; set; }
            public virtual OvertimeType OvertimeType { get; set; }
            public virtual Customer Customer { get; set; }

            public virtual List<Approve_History> Approve_Histories { get; set; }
        }

        public class Approve_History
        {
            [Key]
            public int id { get; set; }
            public DateTime date { get; set; }
            public string status { get; set; }
            public int Overtime_id { get; set; }
            public virtual DataOvertime DataOvertime { get; set; }
        }

       
    }
}
