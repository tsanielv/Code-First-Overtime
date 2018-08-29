using System;
using CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Controller
{
    class EmployeeController
    {
        BaseContext _context = new BaseContext();
        public void Menu()
        {
            BaseContext _context = new BaseContext();
            int input;

            System.Console.WriteLine("====================================");
            Console.WriteLine("1. Insert Data Type Overtime");
            Console.WriteLine("2. Lihat  Data Semua Type Overtime");
            Console.WriteLine("3. Get By ID Type Overtime");
            Console.WriteLine("4. Update Data Type Overtime");
            Console.WriteLine("5. Delete Data Type Overtime");
            Console.WriteLine("====================================");
            Console.Write("Pilih Menu = ");
            int pilih = Convert.ToInt32(Console.ReadLine());

            switch (pilih)
            {
                case 1:
                    Insert();
                    Console.ReadKey();
                    break;

                case 2:
                    GetAll();
                    Console.ReadKey();
                    break;

                case 3:
                    
                    break;

                case 4:
                    
                    break;

                case 5:
                    
                    break;
            }
        }


        public void Insert()
        {

            Console.Write("Masukkan Nama           : ");
            string name_employee = Console.ReadLine();
            Console.Write("Masukkan Alamat         : ");
            string address_employee = Console.ReadLine();
            Console.Write("Masukkan Gender         : ");
            string gender_employee = Console.ReadLine();
            Console.Write("Masukkan Email          : ");
            string email_employee = Console.ReadLine();
            Console.Write("Masukkan Password       : ");
            string password_emlpoyee = Console.ReadLine();
            Console.Write("Masukkan Salary         : ");
            int salary_employee = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Department ID  : ");
            int department_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Role ID        : ");
            int role_id = Convert.ToInt32(Console.ReadLine());

            Employee employee = new Employee()
            {
                name = name_employee,
                address = address_employee,
                gender = gender_employee,
                email = email_employee,
                password = password_emlpoyee,
                salary = salary_employee,
                departmentsId = department_id,
                rolesId = role_id
            };
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.InnerException);
                Console.Write(e.Message);
                Console.Write(e.StackTrace);
            }
        }

        public List<Employee> GetAll()
        {
            Console.Clear();

            var getAll = _context.Employees.ToList();
            var d = (from Employee in _context.Employees
                     join Department in _context.Departments on Employee.departmentsId equals Department.id
                     join Role in _context.Roles on Employee.roleId equals Role.id
                     select new { Employee.name, Employee.address, Employee.gendar, Employee.email, Employee.password, Employee.salary, dname = Department.name, rname = Role.name }).ToList();
            for(int i=0; i<=d.Count(); i++)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Nama       : " + d[i].name);
                Console.WriteLine("Address    : " + d[i].address);
                Console.WriteLine("Gender     : " + d[i].gender);
                Console.WriteLine("Email      : " + d[i].email);
                Console.WriteLine("Password   : " + d[i].password);
                Console.WriteLine("Salary     : " + d[i].salary);
                Console.WriteLine("Department : " + d[i].dname);
                Console.WriteLine("Role       : " + d[i].rname);
                Console.WriteLine("-------------------------");
            }

            return getAll;
        }


        
    }
}
