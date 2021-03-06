﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
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
            public string gender { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public int salary { get; set; }

            //id id yang diambil dari tabel lain dituliskan dengan nama yang berbeda dari properti virtual (nama properti virtual tabel_field)
            public int departmentsId { get; set; }
            public int rolesId { get; set; }
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
            public string type { get; set; }
            public int amount { get; set; }
            public virtual List<DataOvertime> DataOvertimes { get; set; }

        }

        public class OvertimeType
        {
            [Key]
            public int id { get; set; }
            public string type { get; set; }
            public string detail { get; set; }
            public int amount { get; set; }
            public virtual List<DataOvertime> DataOvertimes { get; set; }
        }

        public class DataOvertime
        {
            [Key]
            public int id { get; set; }
            public DateTime date { get; set; }
            public string status { get; set; }

            public int employeeID { get; set; }
            public int taxID { get; set; }
            public int overtimeTypeID { get; set; }
            public int customerID { get; set; }


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
            
            public virtual DataOvertime DataOvertime { get; set; }
        }
}
